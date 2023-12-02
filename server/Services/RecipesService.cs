



namespace all_spice.Services;

public class RecipesService
{

    private readonly RecipesRepository _recipesRepository;

    public RecipesService(RecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _recipesRepository.CreateRecipe(recipeData);
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _recipesRepository.GetRecipes();
        return recipes;
    }
    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _recipesRepository.GetRecipeById(recipeId);

        if (recipe == null)
        {
            throw new Exception($"{recipeId} is not a valid Id");
        }
        return recipe;
    }

    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData, string userId)
    {
        Recipe originalRecipe = GetRecipeById(recipeId);
        if (originalRecipe.CreatorId != userId)
        {
            throw new Exception("NOT YOUR RECIPE TO UPDATE");
        }

        originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
        originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
        originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
        originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;

        _recipesRepository.UpdateRecipe(originalRecipe);
        return originalRecipe;
    }

    internal string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("Not your recipe");
        }
        _recipesRepository.DestroyRecipe(recipeId);
        return "Recipe has been deleted.";
    }
}
