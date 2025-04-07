<template>
    <Navbar></Navbar>
    <RouterLink to="/todocreate"></RouterLink>
  
    <v-container>
      <!-- Title and Description TextBoxes -->
      <v-text-field
        v-model="title"
        label="Title"
        outlined
        dense
        class="mb-4"
      ></v-text-field>
  
      <v-text-field
        v-model="task"
        label="Task"
        outlined
        dense
        class="mb-4"
      ></v-text-field>
  
      <!-- User Dropdown -->
      <v-select 
        v-model="selectedUser"
        :items="users" 
        item-title="name" 
        item-value="id"
        label="User" 
        class="centered-select" 
        dense 
        outlined
      >
        <template v-slot:item="{ props: itemProps, item }">
          <v-list-item v-bind="itemProps" :subtitle="item.birthdate" :key="item.id"></v-list-item>
        </template>
      </v-select>
  
      <!-- Save Button -->
      <v-btn @click="saveData" color="primary" class="mt-4">Save</v-btn>
    </v-container>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import axios from 'axios';
  import Navbar from '@/components/Navbar.vue';
  
  document.title = "Todo | Create";
  
  const title = ref('');  // Title field
  const task = ref('');  // Description field
  const users = ref([]);
  const selectedUser = ref(null);  // Add this to store the selected user
  
  const getAlluser = async () => {
    try {
      const response = await axios.get('http://localhost:3300/api/user');
      users.value = response.data;
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };
  
  const saveData = async () => {
  try {
    console.log('Selected User:', selectedUser.value);  // Check the selected user
    const response = await axios.post('http://localhost:3300/api/todo', {
      title: title.value,
      task: task.value,
      user: selectedUser.value // Use the selected user's ID
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
    max-width: 400px;
    margin: 0 auto;
  }
  </style>
  