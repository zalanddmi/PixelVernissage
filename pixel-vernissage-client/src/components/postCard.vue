<script>
  export default {
    data() {
      return {
        data: null,
      };
    },
    methods: {
      async fetchData() {
        const response = await fetch("https://api.skapex.ru/api/Genre/1");
        this.data = await response.json();
      }
    },
    mounted(){
      this.fetchData()
    }
  };
</script>

<template>
    <div>
        <img @click="$router.push({name: 'PicturePage'})" src="../testphoto/ee2a265d6653bc8746b93dacad536bcb.png">
        <p @click="$router.push({name: 'PicturePage'})">Name picture</p>
        <div class="autor">
            <svg @click="$router.push({name: 'Profile'})" viewBox="-2.88 -2.88 21.76 21.76" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"><rect x="-2.88" y="-2.88" width="21.76" height="21.76" rx="10.88" fill="#ffffff" strokewidth="0"></rect></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="m 8 1 c -1.65625 0 -3 1.34375 -3 3 s 1.34375 3 3 3 s 3 -1.34375 3 -3 s -1.34375 -3 -3 -3 z m -1.5 7 c -2.492188 0 -4.5 2.007812 -4.5 4.5 v 0.5 c 0 1.109375 0.890625 2 2 2 h 8 c 1.109375 0 2 -0.890625 2 -2 v -0.5 c 0 -2.492188 -2.007812 -4.5 -4.5 -4.5 z m 0 0" fill="#2e3436"></path> </g></svg>
            <p @click="$router.push({name: 'Profile'})" style="font-size: 20px;">Name autor</p>
        </div>
    </div>
</template>

<style scoped>
    svg{
        width: 50px;
        height: 50px;
        margin-left: 10px;
        cursor: pointer;
    }
    div{
        width: 300px;
        margin-bottom: 40px;
    }
    img{
        border-radius: 15px;
        width: 100%;
        cursor: pointer;
    }
    p{
        margin: 3px 10px;
        font-family: system-ui, 'Open Sans';
        font-weight: bold;
        font-size: 24px;
        color: #3A2113;
        cursor: pointer;
    }
    .autor{
        display: flex;
        align-items: center;
    }
</style>