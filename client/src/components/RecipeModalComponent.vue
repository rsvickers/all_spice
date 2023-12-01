<template>
    <div class="modal fade" id="createRecipeModal" tabindex="-1" role="dialog" aria-labelledby="createRecipeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header bg-success text-white">
                    <h5 class="modal-title" id="createRecipeModal">Create Recipe</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createRecipe()">
                        <div class="mb-3">
                            <label for="title" class="form-label">Title</label>
                            <input v-model="editable.title" placeholder="Title..." required type="text" class="form-control"
                                id="title" />
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})
        const router = useRouter()
        return {
            editable,

            async createRecipe() {
                try {
                    const recipeData = editable.value
                    await recipesService.createRecipe(recipeData)
                    Pop.success('Recipe Created!')
                    editable.value = {}
                    Modal.getOrCreateInstance('#createRecipeModal').hide()
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>