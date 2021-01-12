const products = document.querySelector('.products');

document.addEventListener('DOMContentLoaded', function() {
    // nav menu
    const menus = document.querySelectorAll('.side-menu');
    M.Sidenav.init(menus, {edge: 'right'});
    // add product form
    const forms = document.querySelectorAll('.side-form');
    M.Sidenav.init(forms, {edge: 'left'});
  });

  //render products data
    const renderProduct = (data, id) =>{
        const html = `
        <div class="card-panel product white row" data-id="${id}">
            <img src"/img/No_Foto.png" alt="product thumb">
            <div class="product-details">
            <div class="product-title">${data.title}</div>
            <div class="product-description">${data.descriptions}</div>
        </div>
        <div class="product-delete">
             <i class="material-icons" data-id"${id}">delete_outline</i>
             </div>
         </div>
    `;

    products.innerHTML += html
};

// API GET
const productsElm = document.querySelector('.products');
    $.ajax({
        url:"https://localhost:44337/api/product/", 
        type: "Get", 
        dataType: "json",
        success: function(data){
            for (let index = 0; index < data.length; index++) {
                const element = data[index];
                
                const html = `
                <div class="card-panel product white row" data-id="${element.productId}">
                    <img src="/img/No_Foto.png" alt="product thumb">
                    <div class="product-details">
                    <div class="product-title">${element.title}</div>
                    <div class="product-description">${element.descriptions}</div>
                    </div>
                    <div class="product-delete">
                        <i class="material-icons delete-product" data-id="${element.productId}">delete_outline</i>
                    </div>
                </div>`

                productsElm.innerHTML += html
            }

            //API Delete
            $(".delete-product").click(function(){
                var id=$(this).attr("data-id");
                $.ajax({
                    url:"https://localhost:44337/api/product/delete/" + id, 
                    type: "DELETE",                    
                    
                    contentType:'application/json',

                    success: function() {
                        console.log("Boller fra kobær!");
                        $(`.product[data-id='${id}']`).remove()                        
                    }, error: function(xhr) {
                        console.error("Sut din mors pik!")
                    }
                })
            })
        }
    })

// //Remove product from DOM
// const removeProduct = (id) =>{
    // const product = document.querySelector(`.product[data-id=${id}]`)
    // product.remove();
// };


