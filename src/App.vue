<template>
   <div>
    <b-table small :fields="fields" :items="items" responsive="sm">
      <!-- A virtual column -->
      <template #cell(index)="data">
        {{ data.index + 1 }}
      </template>

      <!-- A custom formatted column -->
      <template #cell(name)="data">
        <b class="text-info">{{ data.item.value.firstName }}</b>, <b>{{ data.item.value.lastname }}</b>
      </template>
    </b-table>
  </div>
</template>

<script>
import axios from 'axios'
  export default {
    name: "App",
    data() {      
            return {
        fields: [
          // A virtual column that doesn't exist in items
          'index',
          // A column that needs custom formatting
         'firstName',
         'lastName',
          // A regular column
          'mobilenumber'
        ],
        items: []
      }
    },
    mounted () {
    axios
      .get('https://lively-wave-051b7f910.azurestaticapps.net/api/getcustomers')
      .then(response => (this.items = response.data, console.warn(response.data)))
  }
  
}
</script>
