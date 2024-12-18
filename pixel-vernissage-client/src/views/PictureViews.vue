<script>
  export default {
    data() {
      return {
        data: null,
      };
    },
    components:{
    },
    methods: {
    },
    mounted(){
    }
  };
</script>

<template>
  <div>
    <div class="head">
      <p class="title" @click="$router.push({name: 'Home'})">Пиксеный вернитаж</p>
      <div class="rBut">
        <svg class="accauntSvg" @click="$router.push({name: 'Profile'})" viewBox="-2.88 -2.88 21.76 21.76" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"><rect x="-2.88" y="-2.88" width="21.76" height="21.76" rx="10.88" fill="#ffffff" strokewidth="0"></rect></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="m 8 1 c -1.65625 0 -3 1.34375 -3 3 s 1.34375 3 3 3 s 3 -1.34375 3 -3 s -1.34375 -3 -3 -3 z m -1.5 7 c -2.492188 0 -4.5 2.007812 -4.5 4.5 v 0.5 c 0 1.109375 0.890625 2 2 2 h 8 c 1.109375 0 2 -0.890625 2 -2 v -0.5 c 0 -2.492188 -2.007812 -4.5 -4.5 -4.5 z m 0 0" fill="#2e3436"></path> </g></svg>
      
    </div>
    </div>
    <div class="body">
        <div>
            <img src="../testphoto/ee2a265d6653bc8746b93dacad536bcb.png">
        </div>
        <div>
            <div class="description">
                <div class="firstLine">
                    <svg class="likeSvg" viewBox="0 0 32.00 32.00" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" fill="#3A2113" stroke="#3A2113" stroke-width="0.96"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round" stroke="#CCCCCC" stroke-width="0.192"></g><g id="SVGRepo_iconCarrier"> <g id="icomoon-ignore"> </g> <path d="M21.886 5.115c3.521 0 6.376 2.855 6.376 6.376 0 1.809-0.754 3.439-1.964 4.6l-10.297 10.349-10.484-10.536c-1.1-1.146-1.778-2.699-1.778-4.413 0-3.522 2.855-6.376 6.376-6.376 2.652 0 4.925 1.62 5.886 3.924 0.961-2.304 3.234-3.924 5.886-3.924zM21.886 4.049c-2.345 0-4.499 1.089-5.886 2.884-1.386-1.795-3.54-2.884-5.886-2.884-4.104 0-7.442 3.339-7.442 7.442 0 1.928 0.737 3.758 2.075 5.152l11.253 11.309 11.053-11.108c1.46-1.402 2.275-3.308 2.275-5.352 0-4.104-3.339-7.442-7.442-7.442v0z" fill="#3A2113"> </path> </g></svg>
                    <p>CountLike</p>
                    <svg class="menuSvg" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" stroke="#3A2113"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="M7 12C7 13.1046 6.10457 14 5 14C3.89543 14 3 13.1046 3 12C3 10.8954 3.89543 10 5 10C6.10457 10 7 10.8954 7 12Z" fill="#3A2113"></path> <path d="M14 12C14 13.1046 13.1046 14 12 14C10.8954 14 10 13.1046 10 12C10 10.8954 10.8954 10 12 10C13.1046 10 14 10.8954 14 12Z" fill="#3A2113"></path> <path d="M21 12C21 13.1046 20.1046 14 19 14C17.8954 14 17 13.1046 17 12C17 10.8954 17.8954 10 19 10C20.1046 10 21 10.8954 21 12Z" fill="#3A2113"></path> </g></svg>
                </div>
                <div class="firstLine">
                    <svg class="accauntSvg" @click="$router.push({name: 'Profile'})" viewBox="-2.88 -2.88 21.76 21.76" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"><rect x="-2.88" y="-2.88" width="21.76" height="21.76" rx="10.88" fill="#ffffff" strokewidth="0"></rect></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="m 8 1 c -1.65625 0 -3 1.34375 -3 3 s 1.34375 3 3 3 s 3 -1.34375 3 -3 s -1.34375 -3 -3 -3 z m -1.5 7 c -2.492188 0 -4.5 2.007812 -4.5 4.5 v 0.5 c 0 1.109375 0.890625 2 2 2 h 8 c 1.109375 0 2 -0.890625 2 -2 v -0.5 c 0 -2.492188 -2.007812 -4.5 -4.5 -4.5 z m 0 0" fill="#2e3436"></path> </g></svg>
                    <p>Name author</p>
                    <button type="button" value="Input">Подписаться</button>
                </div>
                <p style="margin-left: 30px;">Name picture</p>
                <p style="margin-left: 30px;">Description picture</p>
                <p style="margin-left: 30px;">Цена - Status</p>
                <ul style="margin-left: 30px;">
                    <li></li>
                </ul>
            </div>
            <div>
                
            </div>
        </div>
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
  .body{
    display: grid;
    grid-template-columns: 1fr 2fr;
  }
  img{
    width: 650px;
  }
  .title{
    cursor: pointer;
    font-size: 36px;
    margin-left: 34px;
  }
  p{
    font-size: 18px;
    font-family: system-ui, 'Open Sans';
  }
  .rBut{
    margin-left: auto;
  }
  .likeSvg{
    height: 30px;
    width: 30px;
  }
  .menuSvg{
    margin-left: auto;
    margin-right: 20px;
    height: 50px;
    width: 50px;
  }
  .accauntSvg{
    cursor: pointer;
    margin-right: 20px;
    height: 45px;
    width: 45px;
  }
  .description{
    background-color: #ede4dd;
  }
  .firstLine{
    margin-left: 30px;
    display: flex;
    align-items: center;
    padding: 0.1px; 
  }
  button{
    border-radius: 50px;
    height: 40px;
    width: 180px;
    font-family: system-ui, 'Open Sans';
    font-size: 18px;
    color:#6F484D;
    background-color: #D8D4D1;
    margin-left: auto;
    margin-right: 20px;
    border: none;
  }
</style>
