const staticCacheName = 'site-static-v0';
const dynamicCacheName = 'site-dynamic-v0';
const assets = [
    '/',
    '/index.html',
    '/jS/app',
    '/jS/Ui.js',
    '/jS/materialize.min.js',
    '/JS/capture.js',
    '/JS/Jquery.js',
    '/CSS/Camera.css',
    '/CSS/materialize.min.css',
    '/CSS/StyleSheet.css',
    'https://fonts.googleapis.com/icon?family=Material+Icons',
    'https://fonts.gstatic.com/s/materialicons/v47/flUhRq6tzZclQEJ-Vdg-IuiaDsNcIhQ8tQ.woff2',
    '/Pages/fallback.html'
];

//Cache size limit function
const limitcacheSize = (name, size) =>{
    caches.open(name).then(cache =>{
        Cache.keys().then(keys =>{
            if(keys.length > size){
                cache.delete(keys[0]).then(limitcacheSize(name, size)) //Delete the first item in the Array
            }
        })
    })
};

//Install Event
self.addEventListener('install', evt =>{
    evt.waitUntil(
        caches.open(staticCacheName).then((cache) =>{
            console.log('caching shell assets');
            cache.addAll(assets);
        })
    );
});

// activate event
self.addEventListener('activate', evt => {
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== staticCacheName && key !== dynamicCacheName)
                .map(key => caches.delete(key))
                );
        })
    );
});

