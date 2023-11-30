namespace all_spice.Models;
public class FavoriteRecipe : Recipe
{
    public int FavoriteId { get; set; }
    public string AccountId { get; set; }
}