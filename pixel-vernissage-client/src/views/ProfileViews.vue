<script>
  import postCard from "../components/postCard.vue"
  import testCard from "../components/testCard.vue"

  export default {
    data() {
      return {
        data: null,
      };
    },
    components:{
      postCard,
      testCard
    },
    methods: {
      async fetchData() {
        // const response = await fetch("https://api.skapex.ru/api/Genre/1");
        // this.data = await response.json();
        const profInfo = await fetch("https://api.skapex.ru/api/User/1/public");
        this.data = await profInfo.json();
      }
    },
    mounted(){
      this.fetchData()
    }
  };
</script>

<template>
    <div v-if="data">
      <div class="head">
        <p @click="$router.push({name: 'Home'})">Пиксеный вернитаж</p>
        <p class="name">{{ data.nickname }}</p>
        <svg width="256px" height="256px" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="M19 13C19.5523 13 20 12.5523 20 12C20 11.4477 19.5523 11 19 11C18.4477 11 18 11.4477 18 12C18 12.5523 18.4477 13 19 13Z" stroke="#6F484D" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path> <path d="M12 13C12.5523 13 13 12.5523 13 12C13 11.4477 12.5523 11 12 11C11.4477 11 11 11.4477 11 12C11 12.5523 11.4477 13 12 13Z" stroke="#6F484D" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path> <path d="M5 13C5.55228 13 6 12.5523 6 12C6 11.4477 5.55228 11 5 11C4.44772 11 4 11.4477 4 12C4 12.5523 4.44772 13 5 13Z" stroke="#6F484D" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path> </g></svg>
      </div>
      <div class="infoAuthor">
        <svg @click="$router.push({name: 'Profile'})" class="avatar" viewBox="-2.88 -2.88 21.76 21.76" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"><rect x="-2.88" y="-2.88" width="21.76" height="21.76" rx="10.88" fill="#ffffff" strokewidth="0"></rect></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="m 8 1 c -1.65625 0 -3 1.34375 -3 3 s 1.34375 3 3 3 s 3 -1.34375 3 -3 s -1.34375 -3 -3 -3 z m -1.5 7 c -2.492188 0 -4.5 2.007812 -4.5 4.5 v 0.5 c 0 1.109375 0.890625 2 2 2 h 8 c 1.109375 0 2 -0.890625 2 -2 v -0.5 c 0 -2.492188 -2.007812 -4.5 -4.5 -4.5 z m 0 0" fill="#2e3436"></path> </g></svg>
        <p>{{data.description}}</p>
        <div class="count">
          <p>10 <br> Картин</p>
        </div>
      </div>
      <div class="box">
        <div class="module" v-for="n in 10"><postCard/></div>
      </div>
    </div>
  </template>

<style scoped>
    .head{
        width: 100%;
        height: 80px;
        color: #6F484D;
        display: flex;
        align-items: center;
        padding: 0.1px;
        font-size: 36px;
        font-weight: bold;
    }
    .name{
      margin-left: auto;
      margin-right: auto;
    }
    p{
        font-family: system-ui, 'Open Sans';
        margin-left: 47px;
    }
    svg{
        margin-right: 20px;    
        margin-left: auto;
        height: 60px;
        width: 60px;
    }
    .infoAuthor{
      background-color: #ede4dd;
      width: 100%;
      height: 200px;
      display: flex;
      align-items: center;
      font-size: 25px;
    }
    .avatar{
      margin-left: 80px;
      width: 150px;
      height: 150px;
    }
    .count{
      margin-left: auto;
      font-size: 25px;
      margin-right: 70px;
      text-align: center;
    }
    .box{
      margin-left: 45px;
      margin-top: 35px;
      display: grid;
      grid-template-columns: repeat(4, 1fr);
    }
</style>