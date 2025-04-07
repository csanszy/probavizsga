<template>
    <Navbar></Navbar>
    <RouterLink to="/usercreate"></RouterLink>
  
    <v-container>
      <v-text-field
        v-model="name"
        label="Name"
        outlined
        dense
        class="mb-4"
      ></v-text-field>      
      <v-text-field
        v-model="iskola"
        label="Iskola"
        outlined
        dense
        class="mb-4"
      ></v-text-field>
      <v-select 
        v-model="selectedVerseny"
        :items="versenyek" 
        item-title="verseny" 
        item-value="id"
        label="Válassz Versenyt" 
        class="centered-select" 
        dense 
        outlined
      ></v-select>
      <v-text-field
        v-model="szazalek"
        label="Százalék"
        outlined
        dense
        class="mb-4"
      ></v-text-field>
  
      <v-btn @click="saveData" color="primary" class="mt-4">Save</v-btn>
    </v-container>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import axios from 'axios';
  import Navbar from '@/components/Navbar.vue';
  
  document.title = "User | Create";
  
  // Declare the data to be saved
  const verseny = ref(''); 
  const iskola = ref(''); 
  const selectedVerseny = ref(null);
  const versenyek = ref([]);
  
  const getAlluser = async () => {
    try {
      const response = await axios.get('http://localhost:5000/api/Versenyek');
      versenyek.value = response.data;
    } catch (error) {
      console.error("Error fetching versenyek:", error);
    }
  };

  const saveData = async () => {
  try {
    console.log('Selected User:', selectedVerseny.value);  // Check the selected user
    const response = await axios.post('http://localhost:5000/api/Diak', {
      title: title.value,
      iskola: task.value,
      verseny: selectedVerseny.value // Use the selected user's ID
    });

    alert('Data saved successfully!');
    console.log('Data saved:', response.data);
  } catch (error) {
    console.error("Error saving data:", error);
  }
};
onMounted(getAlluser);

  </script>
  
  <style scoped>
  .centered-select {
    margin: 0 auto;
  }
  
  .v-select .v-input__slot {
    padding: 0.5rem;
  }
  
  .v-select .v-input__label {
    font-size: 1rem;
  }
  
  .v-container {
    max-width: 360px;
    margin: 0 auto;
  }
  </style>
  