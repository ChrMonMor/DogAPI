<script>
import axios from 'axios'
import { ref } from 'vue'

export default {
  data () {
    return {
      info: null,
      doglist: null,
      race: '',
      sub: null,
    }
  },
  mounted (){
    axios
      .get('https://dog.ceo/api/breeds/image/random')
      .then(response => (this.info = response.data.message))
      .catch(err => (console.log(err)))
    axios
      .get('https://dog.ceo/api/breeds/list/all')
      .then(response => 
      {
        this.doglist = Object.keys(response.data.message);
      })
      .catch(err => (console.log(err)))
      .finally()
  },
  methods: {
    fetch_dog() {
      if (this.race != ''){
        axios
          .get('https://dog.ceo/api/breed/'+this.race+'/images/random')
          .then(response => (this.info = response.data.message))
          .catch(err => (console.log(err)))
      }
      else {
        axios
          .get('https://dog.ceo/api/breeds/image/random')
          .then(response => (this.info = response.data.message))
          .catch(err => (console.log(err)))
      }
    },
    onChange(e){
      this.race = e.target.value
      this.fetch_dog()
    },
  }
}
</script>

<template>
  <select name="selected" id="" @change="onChange($event)">
    <option value="">---Race---</option>
    <option v-for="(key, value) in this.doglist" :value="key"> 
      <p>{{ key }}</p>
    </option>
  </select>
  
  <img :src="info" alt="dog picture">
  <button @click="fetch_dog()">MORE!</button>

</template>

<style scoped>
img {
  height: 1000px;
  width: 1000px;
}
* {
  text-align: center;
  text-transform: capitalize;
  display: block;
  margin-left: auto;
  margin-right: auto;
  font-size: 26px;
}
body {
  margin: 0;
  font-family: 'Playfair Display', serif;
  padding: 0 15px;
}
</style>
