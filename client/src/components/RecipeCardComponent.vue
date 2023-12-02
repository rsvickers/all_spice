<template>
    <div class="backgroundImg mb-5 rounded text-light d-flex flex-column justify-content-between"
        :style="{ backgroundImage: `url(${recipeProp.img})` }">
        <div class="d-flex justify-content-between p-2">
            <p class="p-3 box rounded-pill">{{ recipeProp.category }}</p>
            <i class="mdi mdi-heart fs-4 p-3 text-danger box rounded-pill"></i>
        </div>
        <div class="box rounded p-2">
            <p><b>{{ recipeProp.title }}</b></p>
            <!-- <p>{{ recipeProp.instructions }}</p> -->
        </div>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
export default {
    props: {
        recipeProp: { type: Recipe, required: true },
    },
    setup() {
        return {
            account: computed(() => AppState.account),
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
    background-color: rgba(0, 0, 0, 0.423);
}
</style>