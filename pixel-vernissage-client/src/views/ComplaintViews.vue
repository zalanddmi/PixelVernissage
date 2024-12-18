<template>
    <div class="body">
      <nav class="nav">
        <p> ФОРМА ЖАЛОБЫ </p>
      </nav>
      <div class="container">
        <div class="column">
          <div class="button-group">
            <label><input type="radio"/>Этот человек выдает себя за другого</label>
            <label><input type="radio"/>Это спам</label>
            <label><input type="radio"/>Продажа незаконных или подлежащих правовому регулированию товаров</label>
            <label><input type="radio"/>Изображение обнаженного тела или действий сексуального характера</label>
            <label><input type="radio"/>Враждебные высказывания или символы</label>
            <label><input type="radio"/>Насилие или опасные организации</label>
            <label><input type="radio"/>Травля или преследование</label>
            <label><input type="radio"/>Нарушение прав на интеллектуальную собственность</label>
          </div>
          <p>Описание жалобы<br>
            <textarea placeholder="Введите описание жалобы" rows="1"></textarea>
          </p>
          <p>
            <input @click="$router.push({name: 'Home'})" type="submit" value="Отправить жалобу"/>
          </p>
        </div>
      </div>
    </div>
  </template>
  
  
  <style scoped>
  .body {
    font-family: system-ui, 'Open Sans';
    background-color: #EDE4DD; 
    margin: 0;
  }
  label{
    font-size: 20px;
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
  .radio{
    color: #6F484D;
    font-weight: bold;
    font-size: 35px; /* Уменьшено с 36px до 35px */
    margin: 1%;
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
  .button-group {
    display: flex;
    flex-direction: column;
  }
  .button-group button {
    margin-bottom: 10px;
    padding: 10px;
    border-radius: 20px;
    border: none;
    background-color: #D8D4D1;
    font-size: 20px; /* Уменьшено для кнопок */
    color: #3A2113;
  cursor: pointer;
}
.button-group button:hover {
  background-color: #C8C4C1; /* Цвет при наведении */
}
</style>