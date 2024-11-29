<template>
  <div class="body">
  <div class="blok">
    <div class="error">
      <p>ОШИБКА</p>
    </div>
    <div class="icon">
      <img src="../testphoto/icons8-ошибка-100.png" alt="iconAlt">
    </div>
    <div class="errortext">
      <p>Извините, такой страницы не найдено</p>
    </div>
  </div>
</div>
</template>

<script>
export default {
  data() {
    return {
      iconAlt: 'Иконка ошибки',
    };
  },
};
</script>

<style scoped>
.body {
  font-family: system-ui, 'Open Sans';
  background-color: #EDE4DD;
  display: grid;
  place-items: center;
  min-height: 100vh;
}

.blok {
  background: #FBFBFB;
  border-radius: 35px;
  padding: 50px;
  text-align: center;
  max-width: 60%;
  margin: 0 auto;
  display: grid;
}

.icon {
  margin: 0 auto;
}

.error {
  font-size: 40px;
  color: #3A2113;
  margin-bottom: 20px;
  font-weight: bold;
}

.errortext {
  font-size: 36px;
  color: #3A2113;
  margin-top: 20px;
}

@media (max-width: 750px) {
  .error {
    font-size: 20px;
  }
  .errortext {
    font-size: 16px;
  }
  .blok {  margin-top: 50%;
  }
}
</style>