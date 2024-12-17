<template>
    <div class="body">
      <nav class="nav">
        <p> НАСТРОЙКИ </p>
      </nav>
      <div class="container">
        <div class="column">
          <button class="image-button" @click="uploadPhoto"></button>
          <p>Имя пользователя: {{ username }}</p>
          <p>Почта: {{ email }}</p>
          <p>Телефон: {{ phone }}</p>
        </div>
        <div class="column">
          <p>ФИО: {{ fullName }}</p>
          <p>Telegram: {{ telegram }}</p>
          <p>WhatsApp: {{ whatsapp }}</p>
          <p>Описание о себе: {{ description }}</p>
          <p>
            <button @click="editProfile">Редактировать профиль</button>
            <button @click="logout">Выйти из аккаунта</button>
          </p>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        username: 'Пример пользователя',
        email: 'example@example.com',
        phone: '+1234567890',
        fullName: 'Иван Иванов',
        telegram: '@ivanivanov',
        whatsapp: '+1234567890',
        description: 'Это пример описания о себе.'
      };
    },
    methods: {
      uploadPhoto() {
        alert('Загрузка фото');
      },
      editProfile() {
        // Здесь можно добавить логику для редактирования профиля
        alert('Редактирование профиля');
      },
      logout() {
        // Здесь можно добавить логику для выхода из аккаунта
        alert('Выход из аккаунта');
      }
    }
  };
  </script>
  
  <style scoped>
  .body {
    font-family: system-ui, 'Open Sans';
    background-color: #EDE4DD; 
    margin: 0;
  }
  .nav {
    background-color: #D8D4D1;
    text-align: center;
    position: fixed;
    top: 0; 
    width: 100%; 
    z-index: 10; 
    margin-block-end: 0;
  }
  .nav p {
    color: #6F484D;
    font-weight: bold;
    font-size: 36px;
    margin: 1%;
    margin-block-end: 0;
  }
  .container {
    display: flex;
    justify-content: center;
    align-items: flex-start;
    margin-top: 80px;
  }
  .column {
    flex: 1;
    padding-left: 5%;
    padding-right: 5%;
    padding-top: 1%;
  }
  .image-button {
    width: 250px;
    height: 250px; 
    border-radius: 50%;
    border: none;
    cursor: pointer;
    background-image: url('icons8-male-user-100.png'); 
    background-size: cover;
    display: block;
    margin: 0 auto;   
  }
  .column p {
    color: #3A2113;
    font-size: 36px;
  }
  .column button {
    background-color: #D8D4D1;
    border-radius: 35px; 
    padding: 15px;
    font-size: 30px;
    color: #3A2113;
    cursor: pointer;
  }
  </style>
