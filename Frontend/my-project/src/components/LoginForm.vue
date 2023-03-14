<template>
    <div>
      <h2>Login</h2>
      <form>
        <p v-if="errors.length">
    <b>Please correct the following error(s):</b>
    <ul>
      <li v-for="error in errors" v-bind:key="error">{{ error }}</li>
    </ul>
  </p>
        <div>
          <label for="username">Usename</label>
          <input type="text" id="username" v-model="username">
        </div>
        <br>
        <div>
          <label for="password">Password:</label>
          <input type="password" id="password" v-model="password">
        </div>
        <br>
        <div>
          <button class="tmp" type="submit" @click.prevent="submitForm">Submit</button>
            
        </div>
        <br>
        <router-link to="/Register"><button class="tmp">Register</button></router-link>
      </form>
    </div>
  </template>
  
  <script>
    import axios from "axios";
  export default {
    data() {
      return {
        errors:[],
        username: "",
        password: "",
      };
    },
    methods: {
      async submitForm() {
        const data = {
          user: this.username,
          pas:this.password
        };
        try{
          const response = await axios.get("https://localhost:44356/api/Authentication/Login",{ params: { user: data.user,pas:data.pas } });
          if(response.data.Token!=null&&response.data.Token!=""){
          localStorage.setItem('Token',response.data.Token);
          localStorage.setItem('Role',response.data.Roles);
          this.$router.push('/') 
          }
          else{
            this.errors.push("You enter invalid username or password");
          }
        }
        catch(err){
          this.errors.push("You enter invalid username or password");
        }
      },
    },
  };
  </script>
   <style>
   form {
     display: flex;
     flex-direction: column;
     align-items: center;
     margin-top: 50px;
   }
   label {
     margin-right: 10px;
   }
   input {
     margin-bottom: 10px;
     padding: 5px;
     border-radius: 5px;
     border: none;
     box-shadow: 0px 1px 3px rgba(0, 0, 0, 0.3);
   }


   </style>
   