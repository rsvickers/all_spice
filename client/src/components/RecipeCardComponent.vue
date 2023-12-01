<template>
    <div>
        <p>{{ recipeProp.title }}</p>

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


<style lang="scss" scoped></style>