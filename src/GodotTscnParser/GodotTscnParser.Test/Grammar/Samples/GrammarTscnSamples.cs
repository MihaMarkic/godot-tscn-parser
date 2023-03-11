namespace GodotTscnParser.Test.Grammar.Samples
{
    /// <summary>
    /// A bunch of sample taken from real world scenarios
    /// </summary>
    internal static partial class GrammarTscnSamples
    {
        public const string First = """
            [gd_scene load_steps=8 format=3 uid="uid://d3doqyggcpkeb"]

            [ext_resource type="Script" path="res://Player.cs" id="1_8162q"]
            [ext_resource type="Texture2D" uid="uid://bxacee62lu81" path="res://art/playerGrey_up1.png" id="1_d8csi"]
            [ext_resource type="Texture2D" uid="uid://b70twminywsyj" path="res://art/playerGrey_up2.png" id="2_ljnug"]
            [ext_resource type="Texture2D" uid="uid://81wtq6p1bwfg" path="res://art/playerGrey_walk1.png" id="3_krmrv"]
            [ext_resource type="Texture2D" uid="uid://da45skrrq48dj" path="res://art/playerGrey_walk2.png" id="4_jrmwk"]

            [sub_resource type="SpriteFrames" id="SpriteFrames_707dc"]
            animations = [{
            	"frames": [
            		{
            		"duration": 1.0,
            		"texture": ExtResource("1_d8csi")
            		}, 
            		{
            		"duration": 1.0,
            		"texture": ExtResource("2_ljnug")
            		}
            	],
            "loop": true,
            "name": &"up",
            "speed": 5.0
            }, {
            "frames": [{
            "duration": 1.0,
            "texture": ExtResource("3_krmrv")
            }, {
            "duration": 1.0,
            "texture": ExtResource("4_jrmwk")
            }],
            "loop": true,
            "name": &"walk",
            "speed": 5.0
            }]

            [sub_resource type="CapsuleShape2D" id="CapsuleShape2D_6tr4r"]
            radius = 27.0
            height = 70.0

            [node name="Player" type="Area2D"]
            script = ExtResource("1_8162q")
            metadata/_edit_group_ = true

            [node name="AnimatedSprite2d" type="AnimatedSprite2D" parent="."]
            scale = Vector2(0.5, 0.5)
            sprite_frames = SubResource("SpriteFrames_707dc")
            animation = &"up"

            [node name="CollisionShape2d" type="CollisionShape2D" parent="."]
            shape = SubResource("CapsuleShape2D_6tr4r")

            [connection signal="body_entered" from="." to="." method="_on_body_entered"]
            """;

        public const string Second = """
        [gd_scene load_steps=10 format=3 uid="uid://buj8wisq0l07p"]

        [ext_resource type="Script" path="res://Mob.cs" id="1_k5y70"]
        [ext_resource type="Texture2D" uid="uid://bye51w2ru5vie" path="res://art/enemyFlyingAlt_1.png" id="1_ytrj5"]
        [ext_resource type="Texture2D" uid="uid://dhfn0d6qh0qvy" path="res://art/enemyFlyingAlt_2.png" id="2_bls2m"]
        [ext_resource type="Texture2D" uid="uid://bwrqjt5jq5xfb" path="res://art/enemySwimming_1.png" id="3_j0cqp"]
        [ext_resource type="Texture2D" uid="uid://c5uy3836dmlt5" path="res://art/enemySwimming_2.png" id="4_bnymk"]
        [ext_resource type="Texture2D" uid="uid://cdv0chn06a4bm" path="res://art/enemyWalking_1.png" id="5_kl1oy"]
        [ext_resource type="Texture2D" uid="uid://cr0p08wnu2xm8" path="res://art/enemyWalking_2.png" id="6_h88k2"]

        [sub_resource type="SpriteFrames" id="SpriteFrames_7jrot"]
        animations = [{
        "frames": [{
        "duration": 1.0,
        "texture": ExtResource("1_ytrj5")
        }, {
        "duration": 1.0,
        "texture": ExtResource("2_bls2m")
        }],
        "loop": true,
        "name": &"fly",
        "speed": 3.0
        }, {
        "frames": [{
        "duration": 1.0,
        "texture": ExtResource("3_j0cqp")
        }, {
        "duration": 1.0,
        "texture": ExtResource("4_bnymk")
        }],
        "loop": true,
        "name": &"swim",
        "speed": 3.0
        }, {
        "frames": [{
        "duration": 1.0,
        "texture": ExtResource("5_kl1oy")
        }, {
        "duration": 1.0,
        "texture": ExtResource("6_h88k2")
        }],
        "loop": true,
        "name": &"walk",
        "speed": 3.0
        }]

        [sub_resource type="CapsuleShape2D" id="CapsuleShape2D_r7hl5"]
        radius = 58.0
        height = 120.0

        [node name="Mob" type="RigidBody2D"]
        collision_mask = 0
        gravity_scale = 0.0
        script = ExtResource("1_k5y70")
        metadata/_edit_group_ = true

        [node name="AnimatedSprite2D" type="AnimatedSprite2D" parent="."]
        scale = Vector2(0.75, 0.75)
        sprite_frames = SubResource("SpriteFrames_7jrot")
        animation = &"swim"

        [node name="VisibleOnScreenNotifier2D" type="VisibleOnScreenNotifier2D" parent="."]

        [node name="CollisionShape2D" type="CollisionShape2D" parent="."]
        rotation = 1.5708
        shape = SubResource("CapsuleShape2D_r7hl5")

        [connection signal="screen_exited" from="VisibleOnScreenNotifier2D" to="." method="OnVisibleOnScreenNotifier2DScreenExited"]
        
        """;

        public const string Third = """
            [gd_scene load_steps=8 format=3 uid="uid://hc1rholre01q"]

            [ext_resource type="Script" path="res://Main.cs" id="1_4hmc7"]
            [ext_resource type="PackedScene" uid="uid://05vlkouevqb2" path="res://Mob.tscn" id="2_q46v7"]
            [ext_resource type="PackedScene" uid="uid://g76r1u8cf6n7" path="res://Player.tscn" id="3_s3hlu"]
            [ext_resource type="PackedScene" uid="uid://8guvv3ewr5vx" path="res://Hud.tscn" id="4_10xq1"]
            [ext_resource type="AudioStream" uid="uid://vnabgy5q8g1u" path="res://art/House In a Forest Loop.ogg" id="5_tpwrv"]
            [ext_resource type="AudioStream" uid="uid://bwgfexqh0qy0c" path="res://art/gameover.wav" id="6_1uk8d"]

            [sub_resource type="Curve2D" id="Curve2D_6d42f"]
            _data = {
            "points": PackedVector2Array(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 480, 0, 0, 0, 0, 0, 480, 719, 0, 0, 0, 0, 0, 720, 0, 0, 0, 0, 0, 0)
            }
            point_count = 5

            [node name="Main" type="Node"]
            script = ExtResource("1_4hmc7")
            MobScene = ExtResource("2_q46v7")

            [node name="ColorRect" type="ColorRect" parent="."]
            anchors_preset = 15
            anchor_right = 1.0
            anchor_bottom = 1.0
            grow_horizontal = 2
            grow_vertical = 2
            color = Color(0, 0.25098, 0.25098, 1)

            [node name="Player" parent="." instance=ExtResource("3_s3hlu")]

            [node name="MobTimer" type="Timer" parent="."]
            wait_time = 0.5

            [node name="ScoreTimer" type="Timer" parent="."]

            [node name="StartTimer" type="Timer" parent="."]
            wait_time = 2.0
            one_shot = true

            [node name="StartPosition" type="Marker2D" parent="."]
            position = Vector2(240, 450)

            [node name="MobPath" type="Path2D" parent="."]
            curve = SubResource("Curve2D_6d42f")

            [node name="MobSpawnLocation" type="PathFollow2D" parent="MobPath"]

            [node name="Hud" parent="." instance=ExtResource("4_10xq1")]

            [node name="Music" type="AudioStreamPlayer2D" parent="."]
            stream = ExtResource("5_tpwrv")

            [node name="DeathSound" type="AudioStreamPlayer2D" parent="."]
            stream = ExtResource("6_1uk8d")

            [connection signal="Hit" from="Player" to="." method="GameOver"]
            [connection signal="timeout" from="MobTimer" to="." method="OnMobTimerTimeout"]
            [connection signal="timeout" from="ScoreTimer" to="." method="OnScoreTimerTimeout"]
            [connection signal="timeout" from="StartTimer" to="." method="OnStartTimerTimeout"]
            [connection signal="StartGame" from="Hud" to="." method="NewGame"]
            
            """;
    }
}
