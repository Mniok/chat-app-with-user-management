<template>
    <v-container fluid class="p-0 m-0">
        <v-row class="p-0 m-0">
            <v-column class="navbar-column">
                <!-- TODO nav icons between chat and manage users -->
            </v-column>
            <v-column class="default-slot-column">
                <slot />
            </v-column>
        </v-row>
    </v-container>
</template>

<style lang="scss">
$bar-width: 52px;
.navbar-column {
    min-width: $bar-width;
    background-color: #3F51B5 !important; // vuetify indigo
}
.default-slot-column {
    width: calc(100% - $bar-width);
}
</style>