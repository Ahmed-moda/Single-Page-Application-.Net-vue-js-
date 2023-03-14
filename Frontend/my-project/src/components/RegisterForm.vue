<template>
    <form>
      <p v-if="errors.length">
    <b>Please correct the following error(s):</b>
    <ul>
      <li v-for="error in errors" v-bind:key="error">{{ error }}</li>
    </ul>
  </p>

      <h2>Register Form</h2>
      <div class="container-fluid">
        <div>
        <label for="username">Username:</label>
        <input type="text" id="Username" v-model="Username" required />
      </div>
      <br>
      <div>
        <label for="Firstname">Firstname:</label>
        <input type="text" id="Firstname" v-model="Firstname" required />
      </div>
      <br>
      <div>
        <label for="email">Email:</label>
        <input type="email" id="Email" v-model="Email" required />
      </div>
      <br>
      <div>
        <label for="password">Password:</label>
        <input type="password" id="password" v-model="password"  required />
      </div>
      <br>
      <div>
        <label for="Role">Role:</label>
        <select name="Role" id="Role" v-model="Role">
          <option v-for="(rol,index) in Roles" :value="rol" :key="index">{{ rol }}</option>
    </select>
      </div>
      <br>
      
      <div>
        <button class="tmp" type="submit" @click.prevent="register">Register</button>
        
      </div>
      </div>
   
    </form>
  </template>
  
  <script>
  import axios from "axios";
  export default {
    data() {
      return {
        errors:[],
        Roles:[],
        Username: '',
        Firstname: '',
        Email: '',
        password: '',
        Role: '',
      };
    },
    methods: {
      async register() {
        const data = {
        Username: this.Username,
        Email: this.Email,
        password: this.password,
        Firstname:this.Firstname,
        Role:this.Role
      };
      try {
        this.errors = [];
      if(!this.Username) this.errors.push("Username is required.");
      if(!this.Firstname) this.errors.push("Firstname is required.");
      if(!this.Email) this.errors.push("Email is required.");
      if(!this.password) this.errors.push("password is required.");
      if(!this.Role) this.errors.push("Role is required.");
      if(this.errors.length==0){
        const response = await axios.post("https://localhost:44356/api/Authentication/register", data);
        var tmp=response.data;
        var tok=tmp.Token;
        console.log(tok);
        if(tok!=null&&tok!=""){
          localStorage.setItem('Token',tok);
          localStorage.setItem('Role',tmp.Roles);
          this.$router.push('/') 
        }
        else{
          this.errors.push(tmp.Message)
        }
          
        console.log(response.data);
      }
         // handle the API response
      } catch (e) {
        console.error(e); // handle the API error
      }

    
      },
      async getroles(){
        console.log(5)
      const response =await axios.get("https://localhost:44356/api/Authentication/Getroles"); 
      this.Roles=response.data;
      console.log(this.Roles);
      console.log(response.data);
      }
    },
    mounted(){
     this.getroles();
    }
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
  .tmp {
    margin-top: 10px;
    padding: 5px 10px;
    border-radius: 5px;
    border: none;
    background-color: #2c3e50;
    color: #fff;
    cursor: pointer;
  }
  select{
    margin-bottom: 10px;
    padding: 5px;
    border-radius: 5px;
    border: none;
    box-shadow: 0px 1px 3px rgba(0, 0, 0, 0.3);
  }
  </style>
  