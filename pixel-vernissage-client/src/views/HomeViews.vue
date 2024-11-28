<script>
  import postCard from "../components/postCard.vue"
  export default {
    data() {
      return {
        data: null,
      };
    },
    components:{
      postCard
    },
    methods: {
      async fetchData() {
        // const response = await fetch("https://api.skapex.ru/api/Genre/1");
        // this.data = await response.json();
        const genre = await fetch("https://api.skapex.ru/api/Genre");
        this.data = await genre.json();
      }
    },
    mounted(){
      this.fetchData()
    }
  };
</script>

<template>
  <div>
    <div class="head">
      <p>Пиксеный вернитаж</p>
      <div class="rBut">
        <svg xmlns="http://www.w3.org/2000/svg" fill="#6f484d" width="188px" height="188px" viewBox="0 0 24 24" stroke="#6f484d" stroke-width="0.00024000000000000003"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"><path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z"></path></g></svg>
        <svg @click="$router.push({name: 'Error'})" viewBox="-2.88 -2.88 21.76 21.76" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"><rect x="-2.88" y="-2.88" width="21.76" height="21.76" rx="10.88" fill="#ffffff" strokewidth="0"></rect></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="m 8 1 c -1.65625 0 -3 1.34375 -3 3 s 1.34375 3 3 3 s 3 -1.34375 3 -3 s -1.34375 -3 -3 -3 z m -1.5 7 c -2.492188 0 -4.5 2.007812 -4.5 4.5 v 0.5 c 0 1.109375 0.890625 2 2 2 h 8 c 1.109375 0 2 -0.890625 2 -2 v -0.5 c 0 -2.492188 -2.007812 -4.5 -4.5 -4.5 z m 0 0" fill="#2e3436"></path> </g></svg>
      </div>
    </div>
    <div class="title">
      <h1>ГАЛЛЕРЕЯ ДЕБЮТИРУЮЩИХ ХУДОЖНИКОВ</h1>
      <h3>преврати хобби в работу</h3>
    </div>
    <div>
      <ul>
        <li @click="$router.push({name: 'Cart'})" v-if="data" v-for="item in data" :key="item.id">
          {{ item.name }}
        </li>
      </ul>
    </div>
    <div class="box">
      <div class="module"><postCard/></div>
      <div class="module"><postCard/></div>
      <div class="module"><postCard/></div>
      <div class="module"><postCard/></div>
      <div class="module"><postCard/></div>
      <div class="module"><postCard/></div>
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
  }
  p{
    font-size: 36px;
    font-family: system-ui, 'Open Sans';
    margin-left: 34px;
  }
  .rBut{
    margin-left: auto;
  }
  svg{
    margin-right: 20px;
    height: 45px;
    width: 45px;
  }
  .title{
      padding: 0.1px;
      background-color: #ede4dd;
      width: 100%;
      height: 100px;
      text-align: center;
      font-family: system-ui, 'Open Sans';
      color: #6B625D;
    }
    h1{
      margin-block-end: 0;
    }
    h3{
      margin-top: 0;
    }
    ul{
      display: inline-block;
      overflow: auto;
      overflow-y: hidden;
      width: 95%;
      white-space: nowrap;
      list-style-type: none;
    }
    ul::-webkit-scrollbar{
      background-color: #D8D4D1;
    }
    li{
      cursor: pointer;
      display: inline;
      margin-right: 25px;
      font-family: system-ui, 'Open Sans';
      font-size: 25px;
      color: #6B625D;
    }
    li:hover{
      font-weight: bold;
      text-decoration: underline;
    }
    .box{
      margin-left: 45px;
      display: grid;
      grid-template-columns: repeat(4, 1fr);
    }
  @media (max-width: 480px) {
    .box{
      display: block;
      align-items: center;
    }
    .head{
      width: 100%;
      height: 50px;
      color: #6F484D;
      display: flex;
      align-items: center;
      padding: 0.1px;
    }
    p{
      font-size: 22px;
      font-family: system-ui, 'Open Sans';
      margin-left: 7px;
    }
    .rBut{
      margin-left: auto;
    }
    svg{
      margin-right: 13px;
      height: 25px;
      width: 25px;
    }
    .title{
      background-color: #ede4dd;
      width: 100%;
      height: 160px;
      align-items: center;
      font-family: system-ui, 'Open Sans';
      color: #6B625D;
      padding: 0.1px;
    }
    h1{
      margin-block-start: 0px;
    }
    h3{
      font-family: system-ui, 'Open Sans';
    }
    ul{
      padding-left: 19px;
      display: inline-block;
      overflow: auto;
      overflow-y: hidden;
      width: 94.9%;
      white-space: nowrap;
      list-style-type: none;
    }
    ul::-webkit-scrollbar{
      background-color: #D8D4D1;
    }
    li{
      display: inline;
      margin-right: 13px;
      font-family: system-ui, 'Open Sans';
      font-size: 16px;
      color: #6B625D;
    }
    li:hover{
      font-weight: bold;
      text-decoration: underline;
    }
  }
</style>
