package Vista;

import Modelo.Paleta;
import Modelo.Pelota;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Toolkit;
import java.awt.event.KeyEvent;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;
import java.io.File;
import javax.imageio.ImageIO;
import javax.swing.JOptionPane;

public class Ventana extends javax.swing.JFrame {

    /*
    private BufferedImage imgDibujar, imgFondo;
    boolean dibujoListo;
    String mensaje = "Cargando imagen ...";
    private BufferStrategy bufferStrategy;
     */
    
    //Definimos un tamaño estandar para la ventana
    private int windowWidth = 800;
    private int windowHeight = 600;

    //Tenemos los objetos pelota y paleta
    private Pelota pelota;
    private Paleta paleta;

    //Me va a manejar la tecla que he presionado.
    private int key = 0;

    //Me controla el tiempo en que debe refrescarse o realizarse una jugada.
    private long goal;
    private long tiempoDemora = 40;
    private int flag = 0;
    private int TIEMPO_ROJO = 10;
    private int TIEMPO_BLANCO = 10;
    private int TIEMPO_NORMAL = TIEMPO_ROJO + TIEMPO_BLANCO;
    private int TIEMPO_VERDE = 15;

    //Lleva la cuenta de cuantos aciertos y desaciertos tuve con la paleta.
    private int Buenas;
    private int Malas;

    public Ventana() {
        initComponents();
        setSize(windowWidth, windowHeight);
        //No se pueda maximizar, sea de tamaño fijo.
        setResizable(false);
        //Lo ubico en una posicion relativa de la pantalla del computador.
        setLocation(100, 100);
        setVisible(true);
        //Antes de crear la estrategia se debe hacer visible la ventana
        createBufferStrategy(2);
        inicializoObjetos();
        while (true) {
            Jugar();
            sleep();
        }
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                formKeyPressed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void formKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_formKeyPressed
        key = evt.getKeyCode();
    }//GEN-LAST:event_formKeyPressed

    private void inicializoObjetos() {
        pelota = new Pelota(windowWidth / 2, windowHeight / 2, 5, -5);
        paleta = new Paleta(windowHeight / 2, 80);
    }

    private void Jugar() {

        pelota.x = pelota.x + pelota.veloX;
        pelota.y = pelota.y + pelota.veloY;

        chequearColision();

        if (pelota.x <= 0 || pelota.x >= windowWidth - 40) {
            pelota.veloX = -pelota.veloX;
            ++Malas;
            flag = TIEMPO_NORMAL;
        }

        if (pelota.y <= 20 || pelota.y >= (windowHeight - 40)) { // 20 y 40 son valores de compensacion
            pelota.veloY = -pelota.veloY;
            flag = TIEMPO_NORMAL;
        }

        dibujoPantalla();
    }

    private void chequearColision() {
        
        if ((pelota.x <= 75 && pelota.x >= 60) && pelota.y > paleta.y && pelota.y < paleta.y + paleta.alto) {
            if (pelota.veloX < 0) { //Choque con la paleta izquierda DESDE LA DERECHA
                ++Buenas;
            }
            flag = TIEMPO_NORMAL;
            pelota.veloX = -pelota.veloX;
        }

        if ((pelota.x >= 695 && pelota.x <= 710) && pelota.y > paleta.y && pelota.y < paleta.y + paleta.alto) {
            if (pelota.veloX > 0) { //Choque con la paleta derecha DESDE LA IZQUIERDA
                ++Buenas;
            }
            flag = TIEMPO_NORMAL;
            pelota.veloX = -pelota.veloX;
        }
    }

    private void dibujoPantalla() {
        BufferStrategy bf = this.getBufferStrategy();
        Graphics g = null;

        try {
            g = bf.getDrawGraphics();

            g.setColor(Color.BLACK);
            g.fillRect(0, 0, windowWidth, windowHeight);

            muestroPuntos(g);            
            dibujoPelota(g);
            dibujoPaletas(g);
        } finally {
            g.dispose();
        }
        bf.show();

        Toolkit.getDefaultToolkit().sync();
    }

    private void dibujoPelota(Graphics g) {
        if (flag >= 0 && flag <= TIEMPO_ROJO) {
            g.setColor(Color.RED);            
            flag++;
        } else if (flag >= TIEMPO_ROJO && flag < TIEMPO_NORMAL) {            
            g.setColor(Color.WHITE);
            flag++;
            if (flag == TIEMPO_NORMAL) flag = 0;
        } else if (flag >= TIEMPO_NORMAL && flag <= TIEMPO_NORMAL + TIEMPO_VERDE) {
            g.setColor(Color.GREEN);
            ++flag;
        } else { /* flag >= TIEMPO_NORMLA + TIEMPO_VERDE */
            flag = 0;
            g.setColor(Color.RED);
        }
        
        g.fillOval(pelota.x, pelota.y, 20, 20);
    }

    private void dibujoPaletas(Graphics g) {
        switch (key) {
            case KeyEvent.VK_UP:
                if (paleta.y > 23) {
                    paleta.y = paleta.y - 6;
                }
                break;
            case KeyEvent.VK_DOWN:
                if (paleta.y < windowHeight - 78) {
                    paleta.y = paleta.y + 6;
                }
                break;
            case KeyEvent.VK_E:
                int valor = JOptionPane.showConfirmDialog(null, "Desea Salir", "Salir", JOptionPane.YES_NO_OPTION);
                if (valor == JOptionPane.YES_OPTION) {
                    System.exit(0);
                }
        }
        key = 0;
        g.setColor(Color.LIGHT_GRAY);
        g.fillRect(75, paleta.y, 15, paleta.alto);
        g.fillRect(710, paleta.y, 15, paleta.alto);
    }

    private void muestroPuntos(Graphics g) {
        g.setColor(Color.WHITE);
        g.setFont(new Font("Arial", Font.BOLD, 16));
        g.drawString("Buenas: " + Buenas, 20, 50);

        g.setColor(Color.WHITE);
        g.setFont(new Font("Arial", Font.BOLD, 16));
        g.drawString("Malas: " + Malas, 20, 70);
    }

    private void sleep() {
        goal = (System.currentTimeMillis() + tiempoDemora);
        while (System.currentTimeMillis() < goal) {
            
        }
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}