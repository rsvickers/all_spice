<template>
  <div class="container-fluid">
    <!-- <section class="row position-relative">
      <div class="col-12 p-4">
        <div class="p-3 d-md-flex buttonBg justify-content-center rounded align-items-end w-50 absolute">
          <button class="btn btn text-success mx-2">Home</button>
          <button class="btn btn text-success mx-2">My Recipes</button>
          <button class="btn btn text-success mx-2">Favorites</button>
        </div>
      </div>
    </section> -->

    <section class="row photos mt-4">
      <div class="col-4" v-for="recipe in recipes" :key="recipe.id">
        <RecipeCardComponent :recipeProp="recipe" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';
import RecipeCardComponent from '../components/RecipeCardComponent.vue';

export default {
  setup() {
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      account: computed(() => AppState.account),
      recipes: computed(() => AppState.recipes)
    };
  },
  components: { RecipeCardComponent }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}

.buttonBg {
  background-color: white;
  box-shadow: 1px 1px 10px black;
  // box-sizing: ;
}

.absolute {
  position: absolute;
  left: 26%;
  top: 300%;
}

.photos {
  position: absolute;
  left: 6%;
  top: 33%;
}
</style>
