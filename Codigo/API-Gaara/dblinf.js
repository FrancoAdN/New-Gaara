const us = [
    "5da2a46f37c072e084e8da0a",
    "5da2a46f37c072e084e8da0b",
    "5da2a46f37c072e084e8da0c",
    "5da2a46f37c072e084e8da0d",
    "5da2a46f37c072e084e8da0e",
    "5da2a46f37c072e084e8da0f",
    "5da2a46f37c072e084e8da10",
    "5da2a46f37c072e084e8da11",
    "5da2a46f37c072e084e8da12",
    "5da2a46f37c072e084e8da13"
];

let db = {
    users:[
        {usr: 'Franco', last:'di Nápoli', email:'francoadinapoli@gmail.com', pwd:'1234', admin: true, id:1},
        {usr: 'test', last:'prueba', email:'test@gmail.com', pwd:'test', admin: true, id:2},
        {usr: 'Tomás', last:'Vera', email:'tomas.vera@gmail.com', pwd:'1234', admin: false, id:3},
        {usr: 'Lautaro', last:'Caputo', email:'lautaro.caputo@gmail.com', pwd:'test', admin: false,id:4},
        {usr: 'Matías', last:'Valussi', email:'matias.valussi@gmail.com', pwd:'test', admin: false, id:5},
        {usr: 'Santiago', last:'Latorre', email:'santiago.latorre@gmail.com', pwd:'test', admin: false, id:6},
        {usr: 'Iván', last:'Leszkiewicz', email:'ivan.leszkiewicz@gmail.com', pwd:'test', admin: false,id:7},
        {usr: 'Martin', last:'Bruno', email:'martin.bruno@gmail.com', pwd:'test', admin: false,id:8},
        {usr: 'Iván', last:'Rodriguez', email:'ivan.rodriguez@gmail.com', pwd:'test', admin: false,id:9},
        {usr: 'Marcos', last:'Ortiz', email:'marcos.ortiz@gmail.com', pwd:'test', admin: false,id:10},
        {usr: 'Román', last:'Sammarco', email:'roman.sammarco@gmail.com', pwd:'test', admin: false,id:11},
        {usr: 'Tomás', last:'da Bouza', email:'tomas.dabouza@gmail.com', pwd:'test', admin: false,id:12},
        {usr: 'Pablo', last:'Gimenez', email:'pablo.gimenez@gmail.com', pwd:'test', admin: false,id:13},
        {usr: 'Franco', last:'Oliva', email:'franco.oliva@gmail.com', pwd:'test', admin: false,id:14},
        {usr: 'Luca', last:'Roma', email:'luca.roma@gmail.com', pwd:'test', admin: false,id:15},
        {usr: 'Axel', last:'Gonzalez', email:'axel.gonzalez@gmail.com', pwd:'test', admin: false,id:16},
        {usr: 'Rodrigo', last:'Tarqui', email:'rodrigo.tarqui@gmail.com', pwd:'test', admin: false,id:17}
    ],
    proyects: [
        {creator: 1, state:1, name:'proyect1', desc:'testproyect1', start:'2019-07-01', end: '2019-07-04', id:1},
        {creator: 1, state:1, name:'proyect2', desc:'testproyect2', start:'2019-07-05', end: '2019-07-09', id:2},
        {creator: 2, state:1, name:'Nproyect1', desc:'testproyect1', start:'2019-07-01', end: '2019-07-20', id:3},
        {creator: 2, state:1, name:'Nproyect2', desc:'testproyect2', start:'2019-07-14', end: '2019-08-03', id:4}
    ],
    tasks:[
        {p_id: 1, name:'Tarea1', desc:'1', hours:4, state:1, group: 3, prec: NaN, done: false, id: 1},
        {p_id: 1, name:'Tarea2', desc:'2', hours:5, state:1, group: 7, prec: NaN, done: false, id: 2},
        {p_id: 2, name:'Tarea3', desc:'3', hours:7, state:1, group: 5, prec: NaN, done: false, id: 3},
        {p_id: 2, name:'Tarea4', desc:'4', hours:1, state:1, group: 10, prec: NaN, done: false, id: 4},
        {p_id: 3, name:'Tarea5', desc:'5', hours:20, state:1, group: 1, prec: NaN, done: false, id: 5},
        {p_id: 3, name:'Tarea6', desc:'6', hours:23, state:1, group: 2, prec: NaN, done: false, id: 6},
        {p_id: 4, name:'Tarea7', desc:'7', hours:6, state:1, group: 4, prec: NaN, done: false, id: 7},
        {p_id: 4, name:'Tarea8', desc:'8', hours:8, state:1, group: 8, prec: NaN, done: false, id: 8},
        {p_id: 2, name:'Tarea9', desc:'8', hours:8, state:1, group: 6, prec: NaN, done: false, id: 9},
        {p_id: 3, name:'Tarea10', desc:'8', hours:8, state:1, group: 9, prec: NaN, done: false,id: 10}
    ],
    groups:[
        {id: 1, name: 'Electrónica', users:[us[0], us[2], us[4], us[3], us[7], us[1]]},
        {id: 2, name: 'Programación Web', users:[us[8], us[4], us[6], us[2]]},
        {id: 3, name: 'Programación Desktop', users:[us[0], us[9], us[7]]}, 
        {id: 4, name: 'Mantenimiento Informático', users: [us[5]]},
        {id: 5, name: 'Mantenimiento', users:[us[5]]},
        {id: 6, name: 'Seguridad Informática', users:[us[0], us[2], us[3], us[4]]},
        {id: 7, name: 'Diseño', users:[us[8], us[1]]},
        {id: 8, name: 'Ventas', users:[us[6], us[9]]},
        {id: 9, name: 'Administración', users:[us[3], us[7], us[9]]},
        {id: 10, name: 'Redes', users:[us[4], us[7], us[1]]}
    ],
};

for(let p of db.proyects){
    delete p.creator;
    p["tasks"] = [];
    for(let t of db.tasks){
        t.prec = null;
        if(t.p_id == p.id){
            delete t.p_id;
            p.tasks.push(t);
        }
    }
}


//console.log(JSON.stringify(db.proyects));
console.log(JSON.stringify(db.groups));