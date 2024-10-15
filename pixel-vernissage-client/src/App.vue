<script setup>
  import postCard from "./components/postCard.vue"
</script>

<template>
  <div>
    <div class="head">
      <p>Пиксеный вернитаж</p>
      <input></input>
      <button></button>
    </div>
    <div class="title">
      <h2>ГАЛЛЕРЕЯ<br>ДЕБЮТИРУЮЩИХ<br>ХУДОЖНИКОВ</h2>
      <h3>преврати хобби в работу</h3>
    </div>
    <div>
      <ul>
        <li>Портрет</li>
        <li>Пейзаж</li>
        <li>Натюрморт</li>
        <li>Архитектура</li>
      </ul>
      <postCard/>
    </div>
  </div>
</template>

<style scoped>
  @media (max-width: 480px) {
    .head{
      width: 100%;
      height: 50px;
      color: #6F484D;
      display: flex;
      align-items: center;
    }
    p{
      font-size: 20px;
      font-family: Merriweather;
      margin-left: 5px;
    }
    input{
      width: 5px;
      margin-left: 160px;
    }
    button{
      margin-right: 13px;
      margin-left: auto;
    }
    .title{
      background-color: #ede4dd;
      width: 100%;
      height: 160px;
      text-align: center;
      padding-top: 1px;
      font-family: Merriweather;
      color: #6B625D;
    }
    h3{
      font-family: Merriweather;
    }
    ul{
      list-style-type: none;
    }
    li{
      display: inline;
      margin-right: 10px;
      font-family: Merriweather;
      font-size: 16px;
      color: #6B625D;
    }
    li:hover{
      font-weight: bold;
      text-decoration: underline;
    }
  }
</style>
