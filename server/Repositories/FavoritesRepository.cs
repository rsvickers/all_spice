



namespace all_spice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO 
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);
        SELECT * FROM favorites WHERE id = LAST_INSERT_ID();";

        Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
        return favorite;
    }

    internal void DestroyFavorite(int favoriteId)
    {
        string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1";
        _db.Execute(sql, new { favoriteId });
    }

    internal Favorite GetFavoriteId(int favoriteId)
    {
        string sql = @"
        SELECT 
        fav.*,
        acc.*
        FROM favorites fav 
        JOIN accounts acc ON acc.id = fav.accountId
        WHERE fav.id = @favoriteId;";

        Favorite favorite = _db.Query<Favorite, Profile, Favorite>(sql, (favorite, profile) =>
        {
            favorite.Creator = profile;
            return favorite;
        }, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<FavoriteRecipe> GetFavoriteRecipeByAccountId(string userId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*,
        acc.*

        FROM favorites fav
        JOIN recipes rec ON fav.recipeId = rec.id
        JOIN accounts acc ON acc.id = rec.creatorId
        WHERE fav.accountId = @userId;";

        List<FavoriteRecipe> favoriteRecipes = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>
        (sql, (favorite, favoriteRecipes, profile) =>
        {
            favoriteRecipes.FavoriteId = favorite.Id;
            favoriteRecipes.AccountId = favorite.AccountId;
            favoriteRecipes.Creator = profile;
            return favoriteRecipes;
        }, new { userId }).ToList();
        return favoriteRecipes;
    }
}