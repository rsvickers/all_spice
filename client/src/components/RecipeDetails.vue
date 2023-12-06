<template>
    <div class="modal modal-xl fade" id="recipeDetailsModal" tabindex="-1" role="dialog"
        aria-labelledby="recipeDetailsModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content modal-xl">
                <!-- <div class="modal-header">
                    <h5 class="modal-title" id="recipeDetailsModalLabel">Hi!!</h5>

                </div> -->
                <div class="modal-body modal-xl">
                    <section class="row">
                        <div class="col-4">
                            <img class="img-fluid" :src="activeRecipe?.img" alt="">
                        </div>
                        <div class="col-8">
                            <div class="p-3 d-flex justify-content-start">
                                <h2 class="text-success">{{ activeRecipe?.title }}</h2>
                                <p class="p-2 box text-white rounded-pill"> {{ activeRecipe?.category }}</p>
                            </div>

                            <section class="p-3 row justify-content-between">
                                <div class="col-5 editBox rounded">
                                    <h4 class="text-white coolBg  rounded text-center">Instructions</h4>
                                    <p>{{ activeRecipe?.instructions }}</p>
                                </div>

                                <div class="col-5 editBox rounded">
                                    <h4 class="text-white coolBg  rounded text-center">Ingredients</h4>
                                    <p v-for="ingredient in ingredients" :key="ingredient.id">{{ ingredient.name }}</p>
                                </div>

                            </section>

                        </div>
                    </section>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn " data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watch } from 'vue';
import { Recipe } from '../models/Recipe';
export default {
    setup() {
        //     watch(AppState.activeRecipe.id, (() => {
        //         getIngredientsByRecipeId()
        //     }))


        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.activeIngredient),
        }
    }
};
</script>


<style lang="scss" scoped>
.funFont {
    font-family: 'Hedvig Letters Serif', serif;
    color: white;
    text-shadow: 2px 2px black;
}

.box {
    // border: solid rgb(255, 255, 255);
    box-shadow: 1px 1px rgba(215, 215, 215, 0.759);
    background-color: rgba(38, 38, 38, 0.421);
}

.editBox {
    box-shadow: 1px 1px rgba(215, 215, 215, 0.759);
    background-color: rgba(200, 200, 200, 0.421);
}

.coolBg {
    background-color: #527360;
}
</style>