


namespace all_spice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
        return favorite;
    }


    internal List<FavoriteRecipe> GetFavoriteRecipeByAccountId(string userId)
    {
        List<FavoriteRecipe> favoriteRecipes = _favoritesRepository.GetFavoriteRecipeByAccountId(userId);
        return favoriteRecipes;
    }


    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _favoritesRepository.GetFavoriteId(favoriteId);
        if (favorite == null)
        {
            throw new Exception($"{favoriteId} is not a valid Id");
        }
        return favorite;
    }
    internal string DestroyFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteById(favoriteId);
        if (favorite.AccountId != userId)
        {
            throw new Exception("Not yours!");
        }
        _favoritesRepository.DestroyFavorite(favoriteId);
        return "Favorite was deleted!";
    }
}