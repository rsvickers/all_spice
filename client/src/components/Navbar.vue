<template>
  <Login />
  <nav>
    <div class="coolBg">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
        <div class="d-flex flex-column align-items-center btn text-success lighten-30 selectable text-uppercase">

        </div>
      </router-link>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarText">
        <ul class="navbar-nav me-auto">
          <li>
            <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
              About
            </router-link>
          </li>
        </ul>
        <!-- LOGIN COMPONENT HERE -->
        <div class="bg-dark">
          <button class="btn text-light bg-dark" @click="toggleTheme"><i class="mdi"
              :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i></button>
        </div>

      </div>
      <div class="container-fluid">
        <section>
          <div class="funFont text-center">
            <h1>All-Spice</h1>
            <h4>Cherish Your Family</h4>
            <h5>And Their Cooking</h5>
          </div>
        </section>
      </div>
    </div>
  </nav>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}

.coolBg {
  background-image: url(https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash-edited-scaled.jpg?fit=2560%2C1437&ssl=1);
  background-size: cover;
  /* background-position: center; */
  min-height: 15rem;
  box-shadow: 1px 1px 15px black;
}

.funFont {
  font-family: 'Hedvig Letters Serif', serif;
  color: white;
  text-shadow: 2px 2px black;
}
</style>
