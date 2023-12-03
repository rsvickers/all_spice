<template>
    <div class="modal modal-lg fade" id="recipeDetailsModal" tabindex="-1" role="dialog"
        aria-labelledby="recipeDetailsModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content modal-lg">
                <div class="modal-header">
                    <h5 class="modal-title" id="recipeDetailsModalLabel">Hi!!</h5>

                </div>
                <div class="modal-body modal-lg">

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
            // recipe: computed(() => AppState.activeRecipe)
        }
    }
};
</script>


<style lang="scss" scoped></style>