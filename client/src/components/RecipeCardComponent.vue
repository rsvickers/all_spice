<template>
    <div class="backgroundImg mb-5 rounded text-light d-flex flex-column justify-content-between" role="button"
        type="button" @click="setActiveRecipe(recipeProp)" :style="{ backgroundImage: `url(${recipeProp?.img})` }">
        <div class="d-flex justify-content-between p-2">
            <p class="p-3 box rounded-pill">{{ recipeProp?.category }}</p>

            <button v-if="!favorite" @click.stop="favoriteTheRecipe()" class="btn"><i
                    class="mdi mdi-heart-outline fs-4 p-3 text-danger box rounded-pill"></i></button>

            <button v-else class="btn"><i class="mdi mdi-heart-outline fs-4 p-3 text-danger box rounded-pill"></i></button>

        </div>
        <div class="box rounded p-2">
            <p><b>{{ recipeProp?.title }}</b></p>

        </div>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
import { recipesService } from '../services/RecipesService.js';
import { Modal } from 'bootstrap';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';

export default {
    props: {
        recipeProp: { type: Recipe, required: true },
    },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            ingredients: computed(() => AppState.activeIngredient),
            favorite: computed(() => AppState.myFavorite.find(recipe => recipe.id == props.recipeProp.id)),


            setActiveRecipe(recipeProp) {
                recipesService.setActiveRecipe(recipeProp)
                this.setActiveIngredient(recipeProp)
                Modal.getOrCreateInstance('#recipeDetailsModal').show()
            },

            setActiveIngredient(recipeProp) {
                const recipeId = recipeProp.id
                recipesService.setActiveIngredient(recipeId)
            },

            async favoriteTheRecipe() {
                try {
                    const recipeId = props.recipeProp.id
                    await recipesService.favoriteTheRecipe(recipeId)

                } catch (error) {
                    Pop.error(error)
                }
            },


        }
    }
};
</script>


<style lang="scss" scoped>
.backgroundImg {
    height: 23rem;
    width: 23rem;
    background-position: center;
    background-size: cover;
    box-shadow: 1px 1px 15px;
}

.box {
    // border: solid rgb(255, 255, 255);
    box-shadow: 1px 1px rgba(215, 215, 215, 0.759);
    background-color: rgba(38, 38, 38, 0.421);
}
</style>