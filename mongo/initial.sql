use pizzapoll

db.createCollection('pizzas')
db.createCollection('goodies')

db.goodies.insertMany([
    {
        _id: "tomatosauce",
        name: "Tomatensauce",
        price: 1.0,
        order_id: 2
    },
    {
        _id: "garlic",
        name: "Knoblauch",
        price: 0.5,
        order_id: 3
    },
    {
        _id: "oregano",
        name: "Oregano",
        price: 0.0,
        order_id: 4
    },
    {
        _id: "oliveoil",
        name: "Olivenöl",
        price: 0.0,
        order_id: 5
    },
    {
        _id: "artichokes",
        name: "Artischoken",
        price: 1.5,
        order_id: 18
    },
    {
        _id: "mushrooms",
        name: "Champignon",
        price: 1.5,
        order_id: 12
    },
    {
        _id: "aubergine",
        name: "Melanzane",
        price: 2.0,
        order_id: 23
    },
    {
        _id: "parmesan",
        name: "Parmesan",
        price: 1.0,
        order_id: 20
    },
    {
        _id: "rucola",
        name: "Rucola",
        price: 2.0,
        order_id: 10
    },
    {
        _id: "cocktailtomatoes",
        name: "frische Cocktailtomaten",
        price: 2.0,
        order_id: 26
    },
    {
        _id: "basil",
        name: "Basilikum",
        price: 1.0,
        order_id: 8
    },
    {
        _id: "fullgrain",
        name: "Integrale / Vollkorn",
        price: 1.5,
        order_id: 34
    },
    {
        _id: "ham",
        name: "Kochschinken",
        price: 1.0,
        order_id: 22
    },
    {
        _id: "mozzarella",
        name: "Mozzarella",
        price: 1.5,
        order_id: 9
    },
    {
        _id: "ricotta",
        name: "Ricotta",
        price: 2.0,
        order_id: 19
    },
    {
        _id: "anchovies",
        name: "Sardellen",
        price: 1.5,
        order_id: 16
    },
    {
        _id: "zucchini",
        name: "Zucchini",
        price: 2.0,
        order_id: 29
    },
    {
        _id: "spicysalami",
        name: "scharfe Salami",
        price: 1.5,
        order_id: 25
    },
    {
        _id: "buffalomozzarella",
        name: "Büffelmozzarella",
        price: 3.5,
        order_id: 6
    },
    {
        _id: "capers",
        name: "Kapern",
        price: 1.5,
        order_id: 17
    },
    {
        _id: "corn",
        name: "Mais",
        price: 0.5,
        order_id: 15
    },
    {
        _id: "blackolives",
        name: "schwarze Oliven",
        price: 1.5,
        order_id: 1
    },
    {
        _id: "pepper",
        name: "Paprika",
        price: 2.0,
        order_id: 21
    },
    {
        _id: "rawham",
        name: "Rohschinken San Daniele",
        price: 3.5,
        order_id: 11
    },
    {
        _id: "tuna",
        name: "Thunfisch",
        price: 2.0,
        order_id: 24
    },
    {
        _id: "onion",
        name: "Zwiebel",
        price: 1.0,
        order_id: 28
    }
])

db.pizzas.insertMany([
    {
        name: "Pizza Pane",
        description: "Pizzateig, gewürzt mit feinsten italienischen Kräutern",
        price: 4.0,
        default_goodies: [],
        additional_goodies: ["fullgrain", "garlic"],
        product_order_id: "1025786136",
        product_customize_id: "1060500666",
        product_image_path: "img/pizzapane.png"
    },
    {
        name: "Pizza Marinara",
        description: "Manchmal ist weniger einfach mehr. Diese Pizza ist der kulinarische Beweis",
        price: 7.5,
        default_goodies: ["garlic", "oliveoil", "tomatosauce", "oregano"],
        additional_goodies: ["artichokes", "mushrooms", "garlic", "aubergine", "oliveoil", "parmesan", "rucola", "tomatosauce", "cocktailtomatoes", "basil", "fullgrain", "ham", "mozzarella", "oregano", "ricotta", "anchovies", "zucchini", "spicysalami", "buffalomozzarella", "capers", "corn", "blackolives", "pepper", "rawham", "tuna", "onion"],
        product_order_id: "1025786096",
        product_customize_id: "1060500626",
        product_image_path: "img/pizzamarinara.png"
    },
    {
        name: "Pizza Margherita",
        description: "Der Klassiker",
        price: 4.0,
        default_goodies: [],
        additional_goodies: ["artichokes", "mushrooms", "garlic", "aubergine", "oliveoil", "parmesan", "rucola", "tomatosauce", "cocktailtomatoes", "basil", "fullgrain", "ham", "mozzarella", "oregano", "ricotta", "anchovies", "zucchini", "spicysalami", "buffalomozzarella", "capers", "corn", "blackolives", "pepper", "rawham", "tuna", "onion"],
        product_order_id: "1025786136",
        product_customize_id: "1060500666",
        product_image_path: "img/pizzamargherita.png"
    },
    {
        name: "Pizza Due Sapori",
        description: "Eine herzhafte Pizza mit Tomatensauce, Mozzarella, Basilikum, Kochschinken, Champignons und Olivenöl",
        price: 4.0,
        default_goodies: [],
        additional_goodies: ["artichokes", "mushrooms", "garlic", "aubergine", "oliveoil", "parmesan", "rucola", "tomatosauce", "cocktailtomatoes", "basil", "fullgrain", "ham", "mozzarella", "oregano", "ricotta", "anchovies", "zucchini", "spicysalami", "buffalomozzarella", "capers", "corn", "blackolives", "pepper", "rawham", "tuna", "onion"],
        product_order_id: "1025786136",
        product_customize_id: "1060500666",
        product_image_path: "img/pizzaduesapori.png"
    }
])