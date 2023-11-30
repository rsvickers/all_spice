


namespace all_spice.Services;
public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
        _ingredientsRepository = ingredientsRepository;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _ingredientsRepository.CreateIngredient(ingredientData);
        return ingredient;
    }


    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _ingredientsRepository.GetIngredientsById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception($"{ingredientId} is not a valid Id");
        }
        return ingredient;
    }

    internal string DestroyIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = GetIngredientById(ingredientId);
        if (ingredient.CreatorId != userId)
        {
            throw new Exception("NOT YOURS");
        }
        _ingredientsRepository.DestroyIngredient(ingredientId);
        return "Ingredient was deleted!";
    }
}