



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

    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData)
    {
        Recipe originalRecipe = GetRecipeById(recipeId);

        originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
        originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
        originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
        originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;

        _recipesRepository.UpdateRecipe(originalRecipe);
        return originalRecipe;
    }
}
