document.addEventListener("DOMContentLoaded", function() {
    includeHTML();
    displayCart();
});

function addToCart(name, image, price) {
    let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    cartItems.push({name, image, price, quantity: 1});
    localStorage.setItem('cartItems', JSON.stringify(cartItems));
    alert('تم إضافة المنتج إلى السلة!');
}

function removeFromCart(index) {
    let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    cartItems.splice(index, 1);
    localStorage.setItem('cartItems', JSON.stringify(cartItems));
    displayCart();
}

function completePurchase() {
    let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    if (cartItems.length === 0) {
        alert('سلتك فارغة!');
        return;
    }
    // تحقق من تعبئة جميع الحقول المطلوبة
    if (!areFieldsFilled()) {
        alert('يرجى ملء جميع الحقول المطلوبة قبل إتمام الشراء');
        return;
    }
    
    localStorage.removeItem('cartItems');
    alert('تمت عملية الشراء بنجاح!');
    displayCart();
}

function includeHTML() {
    var z, i, elmnt, file, xhr;
    z = document.getElementsByTagName("*");
    for (i = 0; i < z.length; i++) {
        elmnt = z[i];
        file = elmnt.getAttribute("w3-include-html");
        if (file) {
            xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function() {
                if (this.readyState == 4 && this.status == 200) {
                    elmnt.innerHTML = this.responseText;
                    elmnt.removeAttribute("w3-include-html");
                    includeHTML();
                }
            }
            xhr.open("GET", file, true);
            xhr.send();
            return;
        }
    }
}

function displayCart() {
    let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    let cartContainer = document.getElementById('cart-items');
    cartContainer.innerHTML = '';

    cartItems.forEach((item, index) => {
        let row = `<tr>
            <td>
                <img src="${item.image}" alt="${item.name}" style="width:50px;height:50px;">
                ${item.name}
            </td>
            <td>${item.quantity}</td>
            <td>$${item.price}</td>
            <td><button onclick="removeFromCart(${index})">إزالة</button></td>
        </tr>`;
        cartContainer.innerHTML += row;
    });
}

function areFieldsFilled() {
    // المنطق للتحقق من تعبئة جميع الحقول المطلوبة
    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const address = document.getElementById('address').value.trim();
    
    return name !== '' && email !== '' && address !== '';
}

document.addEventListener("DOMContentLoaded", function() {
    includeHTML();
    displayCart();
});

// ... باقي الدوال

function completePurchase() {
    let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    if (cartItems.length === 0) {
        alert('سلتك فارغة!');
        return;
    }
    else{
        window.location.href = 'checkout.html';
    }
    // تحقق من تعبئة جميع الحقول المطلوبة
    if (!areFieldsFilled()) {
        alert('يرجى ملء جميع الحقول المطلوبة قبل إتمام الشراء');
        return;
    }

   
}

// ... باقي الدوال