<template>
    <div class="body">
    <nav class="nav">
      <p> СОЗДАНИЕ ПОСТА </p>
    </nav>
    <div class="container">
      <div class="column">
        <button class="image-button" @click="uploadPhoto"></button>
        <p>Название<br>
          <input type="text" v-model="postTitle" placeholder="Введите название" />
        </p>
        
      </div>
      <div class="column">
        <p>Описание<br>
          <textarea v-model="postDescription" placeholder="Введите описание" rows="1"></textarea>
        </p>
        <p>Хештеги<br>
          <input type="text" v-model="hashtags" placeholder="Введите хештеги" />
        </p>
        <p>Категория<br>
          <input type="text" v-model="category" placeholder="Введите категорию" />
        </p>
        <p>Цена<br>
          <input type="number" v-model="price" placeholder="Введите цену" />
        </p>
        <p>
          <input type="submit" value="Опубликовать" @click="publishPost" />
        </p>
      </div>
    </div>
  </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        postTitle: '',
        postContent: '',
        tags: '',
        imageUrl: ''
      };
    },
    methods: {
      uploadPhoto() {
        alert('Загрузка фото');
      },
      createPost() {
        console.log('Пост создан', {
          title: this.postTitle,
          content: this.postContent,
          tags: this.tags.split(',').map(tag => tag.trim()), // Преобразуем строку тегов в массив
          imageUrl: this.imageUrl
        });
        alert('Пост успешно создан!');
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
  font-size: 35px; /* Уменьшено с 36px до 35px */
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
.column p {
  color: #3A2113;
  font-size: 35px; /* Уменьшено с 36px до 35px */
}
.column input,
.column textarea {
  width: 100%;
  padding: 1%;
  border-radius: 35px;
  border: none;
  font-size: 35px; /* Уменьшено с 36px до 35px */
  color: #3A2113;
}
.column input::placeholder,
.column textarea::placeholder {
  color: #A8A8A8;
}
.column input[type="submit"] {
  background-color: #D8D4D1;
  border-radius: 35px; 
  padding: 15px;
  font-size: 29px; /* Уменьшено с 30px до 29px */
  color: #3A2113;
  cursor: pointer;
}
.image-button {
    width: 600px;
    height: 500px; 
    border: none;
    cursor: pointer;
    background-image: url('icons8-male-user-100.png'); 
    background-size: cover;
    display: block;
    margin: 0 auto;   
  }
  </style>