<template>
    <div class="body">
      <nav class="nav">
        <p> СОЗДАНИЕ ПРОФИЛЯ </p>
      </nav>
      <div class="container">
        <div class="column">
          <button class="image-button" @click="uploadPhoto"></button>
          <form @submit.prevent="saveProfile">
            <p>Имя пользователя*<br>
              <input type="text" v-model="username" placeholder="Введите сюда" />
            </p>
            <p>Почта*<br>
              <input type="email" v-model="email" placeholder="Введите сюда" />
            </p>
            <p>Телефон*<br>
              <input type="tel" v-model="phone" placeholder="Введите сюда" />
            </p>
          </form>
        </div>
        <div class="column">
          <form @submit.prevent="saveProfile">
            <p>ФИО<br>
              <input type="text" v-model="fullName" placeholder="Введите сюда" />
            </p>
            <p>Telegram<br>
              <input type="text" v-model="telegram" placeholder="Введите сюда" />
            </p>
            <p>WhatsApp<br>
              <input type="text" v-model="whatsapp" placeholder="Введите сюда" />
            </p>
            <p>Описание о себе<br>
              <input type="text" v-model="description" placeholder="Введите сюда" />
            </p>
            <p><input type="submit" value="Сохранить" /></p>
          </form>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        username: '',
        email: '',
        phone: '',
        fullName: '',
        telegram: '',
        whatsapp: '',
        description: ''
      };
    },
    methods: {
      uploadPhoto() {
        alert('Загрузка фото');
      },
      saveProfile() {
        console.log('Профиль сохранен', {
          username: this.username,
          email: this.email,
          phone: this.phone,
          fullName: this.fullName,
          telegram: this.telegram,
          whatsapp: this.whatsapp,
          description: this.description
        });
        alert('Профиль успешно сохранен!');
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
  
  form p {
    color: #3A2113;
    font-size: 36px;
    margin-top: 1px;
  }
  
  form input {
    width: 100%;
    padding: 1%;
    border-radius: 35px;
    border: none;
    font-size: 36px;
    color: #3A2113;
  }
  
  form input::placeholder {
    color: #A8A8A8;
    font-size: 30px;
    padding-left: 5%;
  }
  
  form input[type="submit"] {
    background-color: #D8D4D1;
    border-radius: 35px; 
    padding: 15px;
    font-size: 30px;
    color: #3A2113;
    cursor: pointer;
  }
  </style>