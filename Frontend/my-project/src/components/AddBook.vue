<template>
    <div>
      <h2>Add Book</h2>
      <form>
        <p v-if="errors.length">
    <b>Please correct the following error(s):</b>
    <ul>
      <li v-for="error in errors" v-bind:key="error">{{ error }}</li>
    </ul>
  </p>
        <div>
          <label >Book Title</label>
          <input type="text" id="Title" v-model="Title">
        </div>
        <br>
        <div>
          <label for="authorid">Author:</label>
          <select name="authorid" id="authorid" v-model="authorid">
      <option v-for="(aut,index) in authors" :value="aut.AuthorId" :key="index">{{ aut.Author }}</option>
    </select>
        </div>
        <br>
        <div>
          <button class="tmp" type="submit" @click.prevent="createbook">Create</button>
            
        </div>
        <br>
        <router-link to="/"><button class="tmp">Home</button></router-link>
      </form>
    </div>
  </template>
  
  <script>
    import axios from "axios";
  export default {
    data() {
      return {
        errors:[],
        authors:[],
        Title: "",
        authorid: "",
      };
    },
    methods: {
      async createbook() {
        const data = {
          Title: this.Title,
          authorid:this.authorid
        };
        try{
            this.errors = [];
      if(!this.Title) this.errors.push("Title is required.");
      if(!this.authorid) this.errors.push("Author is required.");
      if(this.errors.length==0){
        var token=localStorage.getItem('Token');
        const config = {
    headers: { Authorization: `Bearer ${token}` }
};
        const response = await axios.post("https://localhost:44356/api/Books/Create",data,config);
          if(response.data==true){
          this.$router.push('/') 
          }
          else{
            this.errors.push("You enter invalid username or password");
          }
      }
          
        }
        catch(err){
          this.errors.push("You enter invalid username or password");
        }
      },
      async getauthor(){
        try {
        var token=localStorage.getItem('Token');
        const config = {
    headers: { Authorization: `Bearer ${token}` }
    };
        const response = await axios.get("https://localhost:44356/api/Books/Getauthors",config);
        this.authors=response.data;
      
         // handle the API response
      } catch (e) {
        console.error(e); // handle the API error
      }

      }
    },
    mounted(){
        this.getauthor();
    }
  };
  </script>
  <style>
input {
    margin-bottom: 10px;
    padding: 5px;
    border-radius: 5px;
    border: none;
    box-shadow: 0px 1px 3px rgba(0, 0, 0, 0.3);
  }
  select{
    margin-bottom: 10px;
    padding: 5px;
    border-radius: 5px;
    border: none;
    box-shadow: 0px 1px 3px rgba(0, 0, 0, 0.3);
  }

</style>