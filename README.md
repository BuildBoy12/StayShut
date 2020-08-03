# StayShut
Remake of a ServerMod plugin that locks doors when the warhead is on

### Features
Close and lock doors automatically a certain time after the warhead is set off

### Valid Rooms
- 012, 012_BOTTOM, 049_ARMORY, 079_FIRST, 079_SECONDARY, 172, 173_ARMORY, 372, 914, CHECKPOINT_ENT, CHECKPOINT_LCZ_A, CHECKPOINT_LCZ_B, ESCAPE, ESCAPE_INNER, GATE_A, GATE_B, HCZ_ARMORY, HID, HID_LEFT, HID_RIGHT, INTERCOM_LCZ_ARMORY, NUKE_ARMORY, NUKE_SURFACE, SURFACE_GATE

### Configuration

```yaml
stay_shut:
  is_enabled: true
  door_shut_time: 10
  doors_shut:
  - LCZ_ARMORY
  - HCZ_ARMORY
  - NUKE_ARMORY
```
