<template>
    <div class="modal fade" id="createRecipeModal" tabindex="-1" role="dialog" aria-labelledby="createRecipeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header coolBg text-white">
                    <h5 class="modal-title funFont" id="createRecipeModal">Create Recipe</h5>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createRecipe()">
                        <div class="mb-3">
                            <label for="title" class="form-label">Title</label>
                            <input v-model="editable.title" placeholder="Title..." required type="text" class="form-control"
                                id="title" />
                        </div>
                        <div class="mb-3">
                            <label for="category" class="form-label">Category</label>
                            <input v-model="editable.category" placeholder="Title..." required type="text"
                                class="form-control" id="category" />
                        </div>

                        <div class="mb-3">
                            <label for="img" class="form-label">Image</label>
                            <input v-model="editable.img" placeholder="Image..." required type="url" class="form-control"
                                id="img" />
                        </div>

                        <div class="mb-3">
                            <label for="instructions" class="form-label">Instructions</label>
                            <textarea v-model="editable.instructions" class="form-control" placeholder="Instructions..."
                                id="instructions" maxlength="500" rows="3"></textarea>
                        </div>


                        <div class="modal-footer">
                            <button type="button" class="btn " data-bs-dismiss="modal">Close</button>
                            <button type="submit" class="btn btn-success">Create</button>
                        </div>
                    </form>
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
import { Modal } from 'bootstrap';

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


<style lang="scss" scoped>
.coolBg {
    background-color: #527360;
}

.funFont {
    font-family: 'Hedvig Letters Serif', serif;
    color: white;
    text-shadow: 2px 2px black;
}
</style>