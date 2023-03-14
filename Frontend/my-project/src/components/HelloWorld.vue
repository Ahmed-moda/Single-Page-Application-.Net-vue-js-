<template>
  <table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Title</th>
      <th scope="col">Author</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>Jacob</td>
      <td>Thornton</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>Larry</td>
      <td>the Bird</td>
    </tr>
  </tbody>
</table>
</template>

<script>
export default {
    data() {
      return {
        username: "",
        password: "",
      };
    },
    methods: {
      submitForm() {
        console.log("Username: ", this.username);
        console.log("Password: ", this.password);
      },
    },
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->

