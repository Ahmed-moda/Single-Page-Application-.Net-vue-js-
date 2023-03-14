<template>
    <html>
        <head>
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        </head>
        <body>
          <button class="btn btn-primary"  style="float: right;" @click.prevent="logout">log out</button>
          <br>
          <br>
          <router-link to="/Create"><button style="float: right;" class="btn btn-primary"><i class="fa fa-plus"></i> Add Book</button></router-link>
    

<!-- Button trigger modal -->
<table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">#</th>
      <th scope="col">Title</th>
      <th scope="col">Author</th>
      <th v-if="Role=='Admin'">Actions</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="(book,index) in Books" :key="index">
      <th v-text="index+1"></th>
      <td v-text="book.Title"></td>
      <td v-text="book.Author"></td>
      <td v-if="Role=='Admin'"><button class="btn" @click.prevent="Delete(book)"><i class="fa fa-trash" style="color: red;"></i></button></td>
    </tr>
    <td v-if="show" colspan="4" ><h5 class="alert alert-warning text-center">No data to show</h5></td>
  </tbody>
</table>
        </body>
    </html>
    
        

</template>
<script>

import axios from "axios";
  export default {
    data() {
      return {
        Books:[],
        Role:'',
        show:'',
      };
    },
    methods: {
      async Getbooks() {
        
      try {
        var token=localStorage.getItem('Token');
        const config = {
    headers: { Authorization: `Bearer ${token}` }
};
        const response = await axios.get("https://localhost:44356/api/Books/Getall",config);
        this.Books=response.data;
        if(this.Books.length==0){
          this.show=true;
        }
         // handle the API response
      } catch (e) {
        console.error(e); // handle the API error
      }

    
      },
      async Delete(book){
        try {
         var token=localStorage.getItem('Token');
      const config = {
     headers: { Authorization: `Bearer ${token}` }
      };

        const response = await axios.post("https://localhost:44356/api/Books/Delete",book,config

  );
        if(response.data==true){
            this.$router.go()
        }
        else{
    console.log("error");
        }
         // handle the API response
      } catch (e) {
        console.error(e); // handle the API error
      }

      },
      async logout(){
      localStorage.clear();
      this.$router.push('/Login') 
    }
    },
    mounted(){
        this.Role=localStorage.getItem('Role');
        console.log(this.Role);
        if(!this.Role){
            this.$router.push('/Login') 
        }

        this.Getbooks();
        
    },
  };
</script>
<style>




/* Darker background on mouse-over */

</style>