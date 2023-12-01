import { AppState } from "../AppState.js"
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
}

export const recipesService = new RecipesService()