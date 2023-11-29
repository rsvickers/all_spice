


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
}
