<template>
    <div class="modal modal-lg fade" id="recipeDetailsModal" tabindex="-1" role="dialog"
        aria-labelledby="recipeDetailsModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content modal-lg">
                <div class="modal-header">
                    <h5 class="modal-title" id="recipeDetailsModalLabel">Hi!!</h5>

                </div>
                <div class="modal-body modal-lg">
                    <!-- <img class="img-fluid" :src="activeRecipe?.img" alt=""> -->
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
</style>