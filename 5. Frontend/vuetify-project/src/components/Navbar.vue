<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <router-link to="/" class="nav-link">Home</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/todocreate" class="nav-link">TodoCreate</router-link>
        </li>
      <li class="nav-item">
        <router-link to="/usercreate" class="nav-link">UserCreate</router-link>
      </li>
      <li class="nav-item">
        <router-link to="/todolist" class="nav-link">TodoList</router-link>
      </li>
      <li class="nav-item">
        <router-link to="/userlist" class="nav-link">UserList</router-link>
      </li>
      </ul>
    </div>
  </div>
</nav>
</template>

<script setup>

document.title = "Navbar";

</script>
<style scoped>

</style>