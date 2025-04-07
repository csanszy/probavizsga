<template>
    <Navbar></Navbar>
    <RouterLink to="/userlist">
    </RouterLink>
    <v-data-table class="w-25rem"
      v-if="todos.length"
      :headers="headers"
      :items="todos"
      item-key="id"
  ></v-data-table>
</template>
<script setup>
  import axios from "axios";

  import { ref, onMounted } from 'vue';

  const todos = ref([]);
  const headers = ref([
    { title: 'Id', align: 'start', sortable: false, key: 'id' },
    { title: 'Name', align: 'end', key: 'name' },
    { title: 'School', align: 'end', key: 'school' },
    { title: 'Competition', align: 'end', key: 'competition' }, 
    { title: 'Percentage', align: 'end', key: 'percentage' },
  ]);

  const dialog = ref(false);
  const selectedProduct = ref(null);

  const fetchtodos = async () => {
    try {
      const response = await axios.get("http://localhost:5000/api/Diak");
      todos.value = response.data;
      console.log(todos.value);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  onMounted(() => {
    fetchtodos();
  });



import Navbar from '@/components/Navbar.vue';

document.title = "User | List";

</script>
<style scoped>

v-data-table{
    max-width: 500px;
}

</style>