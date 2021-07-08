<template>
    <div>
    <b-table
      :items="items"
      :fields="fields"
      :sort-by.sync="sortBy"
      :sort-desc.sync="sortDesc"
      responsive="sm"
    ></b-table>

    <div>
      Sorting By: <b>{{ sortBy }}</b>, Sort Direction:
      <b>{{ sortDesc ? 'Descending' : 'Ascending' }}</b>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
  export default {
    name: "App",
    data() {      
            return {
        sortBy: 'id',
        sortDesc: false,
        fields: [
          { key: 'lastname', sortable: true },
          { key: 'firstname', sortable: true },
          { key: 'id', sortable: true },
          { key: 'mobilenumber', sortable: false }
        ],
        items: [ ]
      }
    },
    mounted () {
    axios
      .get('/api/getcustomers')
      .then(response => (this.items = response))
  }
  }
</script>
