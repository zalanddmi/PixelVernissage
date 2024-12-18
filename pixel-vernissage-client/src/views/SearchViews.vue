<script>
</script>

<template>
  <div>
    <div class="head">
      <p @click="$router.push({name: 'Home'})">Пиксеный вернитаж</p>
      <form>
        <input type="text" placeholder="Поиск">
        <svg @click="$router.push({name: 'Home'})" class="escape" viewBox="0 0 32 32" xmlns="http://www.w3.org/2000/svg" fill="none"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round" stroke="#CCCCCC" stroke-width="1.024"></g><g id="SVGRepo_iconCarrier"> <path stroke="#6f484d" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M8.5 23.5l15-15M23.5 23.5l-15-15"></path> </g></svg>
      </form>
      <div class="rBut">
        <svg @click="$router.push({name: 'Profile'})" viewBox="-2.88 -2.88 21.76 21.76" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"><rect x="-2.88" y="-2.88" width="21.76" height="21.76" rx="10.88" fill="#ffffff" strokewidth="0"></rect></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="m 8 1 c -1.65625 0 -3 1.34375 -3 3 s 1.34375 3 3 3 s 3 -1.34375 3 -3 s -1.34375 -3 -3 -3 z m -1.5 7 c -2.492188 0 -4.5 2.007812 -4.5 4.5 v 0.5 c 0 1.109375 0.890625 2 2 2 h 8 c 1.109375 0 2 -0.890625 2 -2 v -0.5 c 0 -2.492188 -2.007812 -4.5 -4.5 -4.5 z m 0 0" fill="#2e3436"></path> </g></svg>
      </div>
    </div>
  </div>
</template>

<style scoped>
form {
  position: relative;
  width: 1000px;
  margin: 0 auto;
}
  input {
  border: none;
  outline: none;
  border-radius: 20px;
}
input {
  font-size: 20px;
  width: 100%;
  height: 42px;
  background: #fbfbfb;
  padding-left: 15px;
}
.escape {
  position: absolute;
  top: 0px;
  right: 0px;
  cursor: pointer;
}
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
