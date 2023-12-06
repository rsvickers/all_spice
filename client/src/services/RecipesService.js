import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { Ingredient } from "../models/Ingredient.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {

    async getRecipes() {
        const res = await api.get('api/recipes')
        logger.log('got the recipes', res.data)
        AppState.recipes = res.data.map((r) => new Recipe(r))
    }

    async createRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        logger.log('Created recipe', res.data)
        const newRecipe = new Recipe(res.data)
        AppState.recipes.push(newRecipe)
        return newRecipe
    }

    setActiveRecipe(recipe) {
        AppState.activeRecipe = recipe
    }

    async setActiveIngredient(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        const ingredientData = res.data.map((i) => new Ingredient(i))
        AppState.activeIngredient = ingredientData
    }

    async favoriteTheRecipe(recipeId) {
        const res = await api.post('api/favorites', { recipeId })
        logger.log(res.data, 'anything working?')
        AppState.myFavorite.push(new Favorite(res.data))
        // this.favoriteTheRecipe()
    }

}

export const recipesService = new RecipesService()