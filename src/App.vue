<script>
import axios from 'axios'
import { ref } from 'vue'

export default {
  data () {
    return {
      info: null,
      doglist: null,
      race: '',
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
        this.doglist = response.data.message;
        console.log(response.data.message);
      })
      .catch(err => (console.log(err)))
      .finally()
  },
  methods: {
    getOtherDog() {
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
      this.getOtherDog()
    }
  }
}
</script>

<template>
  <select name="selected" id="" @change="onChange($event)">
      <option value="">---Race---</option>
      <option v-for="(key, value) in this.doglist" :value="value"> {{ value }}</option>
  </select>
  <img :src="info" alt="dog picture">
  <button @click="getOtherDog()">MORE!</button>

</template>

<style scoped>
img {
  height: 400px;
  width: 400px;
}
option {
  text-transform: capitalize;

}
* {
  text-align: center;
  display: block;
  margin-left: auto;
  margin-right: auto;
}
body {
    margin: 0;
    font-family: 'Playfair Display', serif;
    padding: 0 15px;
}
</style>
