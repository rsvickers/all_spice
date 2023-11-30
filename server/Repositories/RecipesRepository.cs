





namespace all_spice.Repositories;

public class RecipesRepository
{

    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO
        recipes(title, instructions, img, category, creatorId)
        VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);
        SELECT rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, recipeData).FirstOrDefault();

        return recipe;
    }


    internal List<Recipe> GetRecipes()
    {
        string sql = @"
        SELECT 
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }).ToList();
        return recipes;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT 
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = @recipeId;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return recipe;

    }

    internal Recipe UpdateRecipe(Recipe originalRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        instructions = @Instructions
        WHERE id = @Id;
        
        SELECT 
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON acc.id = rec.creatorId
        WHERE rec.id = @Id
        ;";


        Recipe newRecipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, originalRecipe).FirstOrDefault();
        return newRecipe;
    }

    internal void DestroyRecipe(int recipeId)
    {
        string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
        _db.Execute(sql, new { recipeId });
    }
}
