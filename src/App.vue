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
import axios from "axios";
  export default {
    name: "App",
    data() {      
      return {
        sortBy: 'status',
        sortDesc: false,
        fields: [
          { key: 'firstName', sortable: true },
          { key: 'lastName', sortable: true },
          { key: 'mobilenumber', sortable: true },
          { key: 'status', sortable: false }
        ],
        items: []
      }
    },
        methods: {
        getitems() {
          axios
            .get("https://lively-wave-051b7f910.azurestaticapps.net/api/getcustomers")
            .then(response => (this.items = response.data));
        }
      }
    }
</script>
