<template>
  <html>
    <head>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    </head>
    <body>
      <div id="app">
    <div class="row">
      <div class="col-sm-6">
        <h1>Welcome to My First .Net & Vue js App</h1>
      </div>
      <div class="col-sm-6">

        <!-- <button class="tmp" v-if="token!=null&&token!=''" style="float: right;" @click.prevent="logout">log out</button> -->
      </div>
    </div>
    
    <!-- <ul class="nav navbar-nav flex-row float-right">
          <li class="nav-item">
            <router-link class="nav-link pr-3" to="/Login">Login</router-link>
          </li>
          <li class="nav-item">
            <router-link class="btn btn-outline-primary" to="/">home</router-link>
          </li>
          <li class="nav-item">
            <router-link class="btn btn-outline-primary" to="/Register">Register</router-link>
          </li>
        </ul>   -->
        <router-view />
        </div>
    </body>
  </html>
  
</template>




<script>

export default {
  data(){
    return {
    token:""
    }
  },
  name: 'App',
  mounted(){
    this.token=localStorage.getItem("Token");
  }


}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
button {
  background-color: RoyalBlue;
  border: none;
  color: white;
  padding: 12px 16px;
  font-size: 16px;
  cursor: pointer;
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
</style>
