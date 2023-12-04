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
                            <div class="p-5 d-flex justify-content-evenly">
                                <h2 class="text-success">{{ activeRecipe?.title }}</h2>
                                <p class="p-2 box text-white rounded-pill"> {{ activeRecipe?.category }}</p>
                            </div>
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
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
export default {


    setup() {
        return {
            activeRecipe: computed(() => AppState.activeRecipe)
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
</style>