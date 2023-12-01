<template>
  <div class="container-fluid">
    <section class="row position-relative">
      <div class="col-12 p-4">
        <div class="p-3 d-none d-md-flex buttonBg justify-content-center rounded align-items-end w-50 absolute">
          <button class="btn btn text-success mx-2">Home</button>
          <button class="btn btn text-success mx-2">My Recipes</button>
          <button class="btn btn text-success mx-2">Favorites</button>
        </div>
      </div>
    </section>

    <section class="row">

    </section>
  </div>
</template>

<script>
import { AppState } from '../AppState';

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      recipe: computed(() => AppState.recipe)
    }
  }
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
</style>
