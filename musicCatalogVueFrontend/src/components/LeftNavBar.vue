<template>
    <v-container fluid class="p-0 m-0">
        <v-row class="entire-screen-height p-0 m-0">
            <div class="navbar-column">
                <!-- TODO nav icons between chat and manage users -->
            </div>
            <v-col class="default-slot-column">
                <slot />
            </v-col>
        </v-row>
    </v-container>
</template>

<style lang="scss">
$footer-thickness: 52px;
$header-thickness: 64px; // on v-app-bar in App.vue
.navbar-column {
    width: $footer-thickness;
    background-color: #3F51B5 !important; // vuetify indigo
}
.default-slot-column {
    width: calc(100% - $footer-thickness);
    height: calc(100vh - $footer-thickness - $header-thickness);
    overflow-y: scroll;
}
.entire-screen-height {
    height: calc(100vh - $footer-thickness - $header-thickness);
}
</style>